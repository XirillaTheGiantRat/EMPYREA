namespace YourEngine
{
    /// <summary>
    /// A generic timer that has a wide range of use cases. Use either the HasFinished boolean property or
    /// connect a class' method to the OnFinished event to handle logic when the timer is finished.
    /// </summary>
    public sealed class Timer
    {
        private float timeLimitInSeconds;

        public Timer(float timeLimitInSeconds) : base()
        {
            this.TimeLimitInSeconds = timeLimitInSeconds;
        }

        // Below are examples of "events". They are very useful:
        // - You do not need to poll (= call every frame) when the timer has
        //   finished, for example, if you "subscribe" to this event.
        // - An event can have many subscribers.
        // - Subscribers are notified immediately.
        // Concept (not C#): https://medium.com/@miladev95/event-driven-programming-cbd3ed8ec2ca
        public delegate void TimerEvent();
        public event TimerEvent? Finished;
        public event TimerEvent? Paused;
        public event TimerEvent? Unpaused;

        public bool HasStarted { get; private set; } = true;
        public bool IsPaused { get; private set; } = false;
        public bool RestartsOnFinish { get; set; } = true;
        public bool IsFinished => this.ElapsedTimeInSeconds >= this.timeLimitInSeconds;
        public float TimeLimitInSeconds
        {
            get => this.timeLimitInSeconds;
            set
            {
                // This is an example of defensive programming: make it easy for your peers
                // to use your code as intended.
                if (value <= 0)
                    throw new Exception("Only positive limits are allowed.");

                this.timeLimitInSeconds = value;
            }
        }
        public float ElapsedTimeInSeconds { get; private set; } = 0;
        public float TimeLeftInSeconds => this.timeLimitInSeconds - this.ElapsedTimeInSeconds;
        public float TimeLeftToTimeLimitRatio => this.TimeLeftInSeconds / this.timeLimitInSeconds;
        public float TimeElapsedToTimeLimitRatio => this.ElapsedTimeInSeconds / this.timeLimitInSeconds;

        /// <summary>
        /// Call this every frame for the timer to work as you would expect.
        /// </summary>
        /// <param name="deltaInSeconds">The time between the current and previous frame in seconds.</param>
        public void Update(float deltaInSeconds)
        {
            // No update if paused.
            if (this.IsPaused)
                return;

            // If not finished, then simply update the elapsed time.
            if (!this.IsFinished)
            {
                this.ElapsedTimeInSeconds += deltaInSeconds;
                HasStarted = false;
                return;
            }
            // Else, handle finishing logic.

            // Cap the elapsed time, so that the elapsed time does not overshoot the limit.
            this.ElapsedTimeInSeconds = this.timeLimitInSeconds;

            if (this.RestartsOnFinish)
                this.Restart();
            else
                this.Pause();

            // Broadcast the finished event for listeners on every finish.
            this.Finished?.Invoke();
        }

        public void Pause()
        {
            // Prevent pausing when the timer is already paused.
            if (this.IsPaused)
                return;

            this.IsPaused = true;
            this.Paused?.Invoke();
        }

        public void Unpause()
        {
            // Prevent unpausing when the timer is already unpaused.
            if (!this.IsPaused)
                return;

            this.IsPaused = false;
            this.Unpaused?.Invoke();
        }

        public void Restart()
        {
            this.ElapsedTimeInSeconds = 0;
            this.Unpause();
            this.HasStarted = true;
        }
        /// <summary>
        /// Skips the timer to a provided percentage of the configured limit in seconds.
        /// </summary>
        /// <param name="percentage">Typically a value between 0 and 1, respectively for 0% and 100%.</param>
        public void SkipTo(float percentage)
        {
            this.ElapsedTimeInSeconds = percentage * this.timeLimitInSeconds;
        }
    }
}

