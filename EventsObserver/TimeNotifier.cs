namespace EventsObserver
{
    using System;
    using System.Threading;

    /// <summary>
    /// Timer which notifies its subscribers when the time is up
    /// </summary>
    public class TimeNotifier
    {
        /// <summary>
        /// Occurs when [time elapsed].
        /// </summary>
        public event EventHandler<TimeElapsedEventArgs> TimeElapsed;

        /// <summary>
        /// Sets the timer.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        public void SetTimer(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            this.OnTimeElapsed(this, new TimeElapsedEventArgs());
        }

        /// <summary>
        /// Called when [time elapsed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeElapsedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTimeElapsed(object sender, TimeElapsedEventArgs e)
        {
            this.TimeElapsed?.Invoke(this, e);
        }
    }
}
