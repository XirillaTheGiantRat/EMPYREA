using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YourEngine
{
    /// <summary>
    /// The base object of everything in your game.
    /// Although this has no visuals, it can still be useful to instance this class
    /// if you use your creativity (hint: you can still add children to it that do
    /// have visuals).
    /// </summary>
    public class GameObject
    {
        private Vector2 direction = Vector2.Zero;
        private float baseDrawLayer = 0;
        private float fineDrawLayer = 0;
        private bool isVisible = true;

        public GameObject() : base()
        {
            // Children can be freely added and removed from a parent
            // without being removed from memory if you store them in
            // references (e.g. properties).
        }

        // Events to facilitate "event-based programming". Let us Google around...
        // Concept (not C#): https://medium.com/@miladev95/event-driven-programming-cbd3ed8ec2ca
        public delegate void GameObjectChangeEvent();
        public event GameObjectChangeEvent? IsVisibleChanged;
        public event GameObjectChangeEvent? Entered;
        public event GameObjectChangeEvent? Exited;
            
        #region Hierarchy
        public int ChildCount => this.Children.Count;
        protected GameObject? Parent { get; private set; } = null;
        private List<GameObject> Children { get; } = new List<GameObject>();
        #endregion

        #region Positioning
        /// <summary>
        /// The coordinates of the object in world space (absolute) retrieved
        /// through recursive calls if this object has a parent.
        /// </summary>
        public Vector2 GlobalPosition
        {
            get
            {
                if (this.Parent == null)
                    return this.LocalPosition;

                return this.LocalPosition + this.Parent.GlobalPosition;
            }
            set
            {
                if (this.Parent == null)
                    this.LocalPosition = value;
                else
                    this.LocalPosition += value - this.GlobalPosition;
            }
        }
        /// <summary>
        /// The coordinates of the object in local space (relative to its parent).
        /// </summary>
        public Vector2 LocalPosition { get; set; } = Vector2.Zero;
        /// <summary>
        /// The scalar of the direction (e.g. how fast this object moves in pixels per second [px/s]).
        /// </summary>
        public float Velocity { get; set; } = 0;
        /// <summary>
        /// In what direction the object should be moved. Any value provided is automatically normalized
        /// in a safe way.
        /// </summary>
        public Vector2 Direction
        {
            get => this.direction;
            set
            {
                // Only normalize the direction if value is not approximately zero (to avoid NaN).
                this.direction = value.IsApproximatelyZero() ? Vector2.Zero : value.Normalized();
            }
        }
        /// <summary>
        /// How much and in what direction the object should be moved (= displaced).
        /// Set the Direction and Velocity properties accordingly to affect this.
        /// </summary>
        public Vector2 Displacement => this.Direction * this.Velocity;
        #endregion

        #region Drawing
        /// <summary>
        /// The product of the parallax factor and camera offset.
        /// </summary>
        public Vector2 ScrollOffset => this.ParallaxFactor * this.CameraOffset;
        /// <summary>
        /// Determines how much a drawable game object will scroll with the camera
        /// (e.g. how far it is into the background). For a component "v" of a Vector2:
        /// v == 0 means no scrolling (e.g. user interface elements).
        /// 1 > v > 0 means relatively slow scrolling (e.g. background elements).
        /// v == 1 means scrolling at a regular pace.
        /// v > 1 means relatively fast scrolling (e.g. foreground elements).
        /// </summary>
        public Vector2 ParallaxFactor { get; set; } = Vector2.One;
        /// <summary>
        /// The offset from the object's global position when it is drawn on screen.
        /// This is related to scrolling and should be determined by an external "camera" instance.
        /// </summary>
        public Vector2 CameraOffset { get; set; } = Vector2.Zero;
        /// <summary>
        /// Whether this object and all of its children should be drawn at all.
        /// Objects are visible by default.
        /// </summary>
        public bool IsVisible
        {
            get => this.isVisible;
            set
            {
                bool hasVisibilityChanged = this.isVisible != value;
                this.isVisible = value;

                if (hasVisibilityChanged)
                    this.IsVisibleChanged?.Invoke();

                for (int i = 0; i < this.Children.Count; ++i)
                    this.Children[i].IsVisible = value;
            }
        }
        /// <summary>
        /// The actual draw layer of this object in the range [0, 1], which is dictated by MonoGame's
        /// "layerDepth" parameter in SpriteBatch's Draw method. Set BaseDrawLayer and FineDrawLayer
        /// to affect this. If two objects have the same value, then the draw order depends on when
        /// each object was created (later added is on top).
        /// </summary>
        public float DrawLayer => this.BaseDrawLayer + this.FineDrawLayer;
        /// <summary>
        /// A value in the range [0, 1].
        /// Overshooting values are automatically clamped.
        /// Be smart about what values you use (in relation to FineDrawLayer).
        /// Pick relatively large values compard to FineDrawLayer (e.g. 0.1f, 0.2f).
        /// </summary>
        public float BaseDrawLayer
        {
            get => this.baseDrawLayer;
            set => this.baseDrawLayer = value.Clamp(0, 1);
        }
        /// <summary>
        /// A value in the range [0, 1] to distinguish between more layers on top of the BaseDrawLayer.
        /// Overshooting values are automatically clamped.
        /// Be smart about what values you use (in relation to BaseDrawLayer).
        /// Pick relatively small values compared to DrawLayer (e.g. 0.001f, 0.002f).
        /// </summary>
        public float FineDrawLayer
        {
            get => this.fineDrawLayer;
            set => this.fineDrawLayer = value.Clamp(0, 1);
        }

        #endregion

        #region Hierarchy manipulating
        public void AddChild(GameObject @object)
        {
            if (@object == this)
                throw new Exception("A child cannot be a child of itself.");

            if (@object.Parent != null)
                throw new Exception("Cannot add child with a parent.");

            @object.Parent = this;
            this.Children.Add(@object);
            @object.Enter();
        }

        public void AddChild(GameObject @object, params GameObject[] objects)
        {
            this.AddChild(@object);

            for (int i = 0; i < objects.Length; ++i)
                this.AddChild(objects[i]);
        }

        public void RemoveChild(GameObject @object)
        {
            @object.Exit();
            @object.Parent = null;
            bool hasChild = this.Children.Remove(@object);

            if (!hasChild)
                throw new Exception("Cannot remove child from non-parent.");
        }

        public void RemoveChild(GameObject @object, params GameObject[] objects)
        {
            this.RemoveChild(@object);

            for (int i = 0; i < objects.Length; ++i)
                this.RemoveChild(objects[i]);
        }

        public void RemoveAllChildren()
        {
            this.Children.Clear();
        }
        #endregion

        #region Updating
        /// <summary>
        /// Called just after the object is added to a parent-child hierarchy.
        /// </summary>
        public void Enter()
        {
            this.EnterSelf();
            this.Entered?.Invoke();
        }
        /// <summary>
        /// Called every frame if the object is part of a parent-child hierarchy.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            this.UpdateSelf(gameTime);
            this.UpdatePosition(gameTime.Delta());

            for (int i = 0; i < this.Children.Count; ++i)
                this.Children[i].Update(gameTime);
        }
        /// <summary>
        /// Called after every Update call if the objct is part of a parent-child hierarchy.
        /// </summary>
        /// <param name="spriteBatch">Use for draw commands.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!this.IsVisible)
                return;

            this.DrawSelf(spriteBatch);

            for (int i = 0; i < this.Children.Count; ++i)
                this.Children[i].Draw(spriteBatch);
        }
        /// <summary>
        /// Called just before the object is removed from a parent-child hierarchy.
        /// </summary>
        public void Exit()
        {
            this.ExitSelf();
            this.Exited?.Invoke();
        }
        /// <summary>
        /// Override this in your concrete class to add unique Enter logic.
        /// Examples: initialization code, subscribing to events...
        /// </summary>
        protected virtual void EnterSelf()
        {
        }
        /// <summary>
        /// Override this in your concrete class to add unique Update logic.
        /// </summary>
        protected virtual void UpdateSelf(GameTime gameTime)
        {
            CameraOffset = Camera.position;
        }
        /// <summary>
        /// Override this in your concrete class to add unique Draw logic.
        /// </summary>
        protected virtual void DrawSelf(SpriteBatch spriteBatch)
        {
        }
        /// <summary>
        /// Override this in your concrete class to add unique Exit logic.
        /// Examples: reset code, deinitialization code, unsubscribing from events...
        /// </summary>
        protected virtual void ExitSelf()
        {
        }
        /// <summary>
        /// Updates the position according to a generic formula.
        /// </summary>
        /// <param name="deltaTime">The time between the previous and current frame in seconds.</param>
        private void UpdatePosition(float deltaTime)
        {
            this.GlobalPosition += this.Displacement * deltaTime;
        }
        #endregion
    }
}
