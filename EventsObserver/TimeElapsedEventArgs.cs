namespace EventsObserver
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// Information about time is up event
    /// </summary>
    /// <seealso cref="T:System.EventArgs" />
    public class TimeElapsedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the invoke time.
        /// </summary>
        /// <value>
        /// The invoke time.
        /// </value>
        public DateTime InvokeTime => DateTime.Now;
    }
}
