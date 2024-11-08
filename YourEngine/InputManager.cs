using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YourEngine
{
    /// <summary>
    /// Handles keyboard and mouse input.
    /// </summary>
    public sealed class InputManager
    {
        // Could differ per mouse, but this value seems to be a norm of sorts.
        private static readonly int SingleScrollDetentAmount = 120;
        private ButtonState leftClick = ButtonState.Released;
        private ButtonState middleClick = ButtonState.Released;
        private ButtonState rightClick = ButtonState.Released;
        private int scrollWheelValue = 0;
        private Keys[] previousPressedKeys = Array.Empty<Keys>();
        private Keys[] pressedKeys = Array.Empty<Keys>();

        public InputManager() : base()
        {
        }



        #region Mouse Movement
        public Vector2 MousePosition { get; private set; } = Vector2.Zero;
        public Vector2 MouseDisplacement { get; private set; } = Vector2.Zero;
        public bool HasMouseMoved { get; private set; } = false;
        public bool IsMouseInsideScreen { get; private set; } = false;
        #endregion

        #region Mouse Scrolling
        public bool HasMouseScrolledDown { get; private set; } = false;
        public  bool HasMouseScrolledUp { get; private set; } = false;
        public bool HasMouseScrolled { get; private set; } = false;
        public int ScrollDisplacement { get; private set; } = 0;
        public int NormalizedScrollDisplacement { get; private set; } = 0;
        #endregion

        #region Mouse Clicking
        public bool HasMouseJustLeftClicked { get; private set; } = false;
        public bool HasMouseJustMiddleClicked { get; private set; } = false;
        public bool HasMouseJustRightClicked { get; private set; } = false;
        public bool HoldLeftClickMouse { get; private set; } = false;
        #endregion

        #region Combinations
        public bool HasMouseDragged { get; private set; } = false;
        #endregion

        #region Keyboard Pressing
        public bool IsAnyKeyPressed { get; private set; } = false;
        public bool IsAnyKeyJustReleased { get; private set; } = false;

        public bool CheckIsKeyPressed(Keys key)
        {
            return this.pressedKeys.Contains(key);
        }

        public bool CheckIsKeyJustPressed(Keys key)
        {
            return !this.previousPressedKeys.Contains(key)
                && this.CheckIsKeyPressed(key);
        }

        public bool CheckIsKeyReleased(Keys key)
        {
            return !this.pressedKeys.Contains(key);
        }

        public bool CheckIsKeyJustReleased(Keys key)
        {
            return this.previousPressedKeys.Contains(key)
                && this.CheckIsKeyReleased(key);
        }
        #endregion

        /// <summary>
        /// Calling this method at the start of every frame is necessary if you want input detection.
        /// </summary>
        public void Update()
        {
            this.ReadMouse();
            this.ReadKeyboard();
        }

        private void ReadMouse()
        {
            // Movement.
            MouseState mouseState = Mouse.GetState();
            Vector2 previousMousePosition = this.MousePosition;
            this.MousePosition = mouseState.Position.ToVector2();
            this.MouseDisplacement = this.MousePosition - previousMousePosition;
            this.HasMouseMoved = !previousMousePosition.IsApproximatelyEqual(this.MousePosition);

            // Scrolling.
            int previousScrollWheelValue = this.scrollWheelValue;
            this.scrollWheelValue = mouseState.ScrollWheelValue;
            this.HasMouseScrolledDown = previousScrollWheelValue > this.scrollWheelValue;
            this.HasMouseScrolledUp = previousScrollWheelValue < this.scrollWheelValue;
            this.HasMouseScrolled = this.HasMouseScrolledDown || this.HasMouseScrolledUp;
            this.ScrollDisplacement = this.scrollWheelValue - previousScrollWheelValue;
            this.NormalizedScrollDisplacement = this.ScrollDisplacement / SingleScrollDetentAmount;
            
            // Clicking.
            ButtonState previousLeftClick = this.leftClick;
            this.leftClick = mouseState.LeftButton;
            ButtonState previousMiddleClick = this.middleClick;
            this.middleClick = mouseState.MiddleButton;
            ButtonState previousRightClick = this.rightClick;
            this.rightClick = mouseState.RightButton;
            bool hasMouseLeftClicked = this.leftClick == ButtonState.Pressed;
            this.HoldLeftClickMouse = hasMouseLeftClicked;
            this.HasMouseJustLeftClicked = (previousLeftClick == ButtonState.Released) && (hasMouseLeftClicked);
            this.HasMouseJustMiddleClicked = (previousMiddleClick == ButtonState.Released) && (this.middleClick == ButtonState.Pressed);
            this.HasMouseJustRightClicked = (previousRightClick == ButtonState.Released) && (this.rightClick == ButtonState.Pressed);

            // Combinations.
            this.HasMouseDragged = this.HasMouseMoved && hasMouseLeftClicked;
        }

        private void ReadKeyboard()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            this.previousPressedKeys = this.pressedKeys;
            this.pressedKeys = keyboardState.GetPressedKeys();
            this.IsAnyKeyPressed = this.pressedKeys.Length > 0;
            this.IsAnyKeyJustReleased = Array.Exists(
                array: this.previousPressedKeys,
                match: key => this.CheckIsKeyJustReleased(key)
                );
        }
        public Keys[] keys { get { return Keyboard.GetState().GetPressedKeys(); } }
    }
}
