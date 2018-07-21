namespace ConsoleTest
{
    using System.Collections.Generic;
    using System.Linq;
    using EventsObserver;
    using System;

    /// <summary>
    /// The abstract test observer
    /// </summary>
    public abstract class AbstractObserver
    {
        /// <summary>
        /// The triggers
        /// </summary>
        private readonly List<string> triggers = new List<string>();

        /// <summary>
        /// Gets the triggers.
        /// </summary>
        /// <returns>
        /// The list of triggers.
        /// </returns>
        public IEnumerable<string> GetTriggers()
        {
            return triggers.ToList();
        }

        /// <summary>
        /// Registers the specified notifier.
        /// </summary>
        /// <param name="notifier">The notifier.</param>
        /// <exception cref="ArgumentException">Throws when notifier is null</exception>
        public void Register(TimeNotifier notifier)
        {
            ValidateOnNull(notifier, nameof(notifier));

            notifier.TimeElapsed += Do;
        }

        /// <summary>
        /// Unregisters the specified notifier.
        /// </summary>
        /// <param name="notifier">The notifier.</param>
        /// <exception cref="ArgumentException">Throws when notifier is null</exception>
        public void Unregister(TimeNotifier notifier)
        {
            ValidateOnNull(notifier, nameof(notifier));

            notifier.TimeElapsed -= Do;
        }

        /// <summary>
        /// Writes the specified event arguments.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeElapsedEventArgs"/> instance containing the event data.</param>
        /// <returns>
        /// Formatted string
        /// </returns>
        protected abstract string Write(object sender, TimeElapsedEventArgs e);

        /// <summary>
        /// Validates object on null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentException">Throws when obj is null</exception>
        private static void ValidateOnNull<T>(T obj, string name) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentException($"{name} is null");
            }
        }

        /// <summary>
        /// Operation to register on event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeElapsedEventArgs"/> instance containing the event data.</param>
        private void Do(object sender, TimeElapsedEventArgs e)
        {
            triggers.Add(Write(sender, e));
        }
    }
}
