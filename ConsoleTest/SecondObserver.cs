namespace ConsoleTest
{
    using EventsObserver;

    /// <inheritdoc />
    /// <summary>
    /// The second test observer
    /// </summary>
    /// <seealso cref="T:ConsoleTest.AbstractObserver" />
    public class SecondObserver : AbstractObserver
    {
        /// <summary>
        /// The counter of invocations
        /// </summary>
        private int counter;

        /// <inheritdoc />
        /// <summary>
        /// Writes the specified event arguments.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="T:EventsObserver.TimeElapsedEventArgs" /> instance containing the event data.</param>
        /// <returns>
        /// Formatted string
        /// </returns>
        protected override string Write(object sender, TimeElapsedEventArgs e) =>
            $"{nameof(SecondObserver)}: invoke #{++this.counter} at {e.InvokeTime:T}";
    }
}
