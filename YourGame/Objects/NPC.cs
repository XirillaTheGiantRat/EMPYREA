using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.States;

namespace YourGame
{
    sealed class NPC : GameObject
    {
        Animation idle, active;
        DialogueReader reader;
        State shopState, displayState;
        bool isIdle, shop;
        public bool Interacting {  get; private set; }
        public NPC(State displayState, bool shop, Animation idleAnimation, 
            Animation activeAnimation,  
            DialogueReader dialogueReader, State shopState)
        {
            this.displayState = displayState;
            this.shop = shop;
            isIdle = true;
            idle = idleAnimation;
            idle.TimePerFrame = 0.2f;
            idle.Repeat = true;
            this.AddChild(idle);
            if (!shop)
            {
                active = activeAnimation;
                active.IsVisible = false;
                active.Run = false;
                active.TimePerFrame = 0.2f;
                this.AddChild(active);
                reader = dialogueReader;
                reader.DialogueRagtangle = new Rectangle(
                    0, YourGame.ScreenSize.Y - reader.Height,
                    YourGame.ScreenSize.X, 128);
                this.shopState = null;
            }
            else
            {
                reader = null;
                this.shopState = shopState;
                active = null;
            }
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            if(isIdle)
            {
                idle.IsVisible = true;
                idle.Run = true;
            }
            else
            {
                idle.IsVisible = false;
                idle.Run = false;
                if(!shop && reader.DialogeEnded)
                {
                    displayState.RemoveChild(reader);
                    StopInteract();
                }
            }
        }
        public void Interact()
        {
            Interacting = true;
            isIdle = false;
            if (!shop)
            {
                displayState.AddChild(reader);
                active.Run = true;
                active.IsVisible = true;
            }
            else
            {
                this.AddChild(shopState);
            }
        }
        public void DialogueSkip()
        {
            if (!shop)
            {
                reader.Skip();
            }
        }
        public void StopInteract()
        {
            isIdle = true;
            Interacting = false;
            if (shop)
            {
                this.RemoveChild(shopState);
            }
            else
            {
                active.IsVisible = false;
                active.Run = false;
            }
        }
    }
}
