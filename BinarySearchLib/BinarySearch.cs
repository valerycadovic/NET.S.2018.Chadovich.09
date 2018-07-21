namespace BinarySearchLib
{
    using System;

    /// <summary>
    /// Binary search class
    /// </summary>
    /// <typeparam name="T">
    /// Type of sorting elements
    /// </typeparam>
    public static class BinarySearch<T>
    {
        #region Public API
        /// <summary>
        /// Searches the element in sorted array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="item">The item.</param>
        /// <param name="compare">The compare.</param>
        /// <returns>
        /// element which was found
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws when array or compare is null
        /// </exception>
        public static int Search(T[] array, T item, Comparison<T> compare)
            => Search(array, item, compare, 0);

        /// <summary>
        /// Searches the element in sorted array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="item">The item.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="start">The start.</param>
        /// <returns>
        /// element which was found
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws when array or compare is null
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">invalid borders</exception>
        public static int Search(T[] array, T item, Comparison<T> compare, int start)
        {
            ValidateOnNull(array, nameof(array));

            return Search(array, item, compare, start, array.Length);
        }

        /// <summary>
        /// Searches the element in sorted array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="item">The item.</param>
        /// <param name="compare">The compare.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>
        /// element which was found
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws when array or compare is null
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">invalid borders</exception>
        public static int Search(T[] array, T item, Comparison<T> compare, int start, int end)
        {
            ValidateOnNull(array, nameof(array));
            ValidateOnNull(compare, nameof(compare));
            ValidateBorders(start, end, array.Length);

            if (array.Length == 0 || compare(item, array[start]) < 0 || compare(item, array[end - 1]) > 0)
            {
                return -1;
            }

            while (end > start)
            {
                int mid = start + (end - start) / 2;

                if (compare(item, array[mid]) <= 0)
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            if (compare(array[end], item) == 0)
            {
                return end;
            }

            return -1;
        }
        #endregion

        #region Private Validation methods
        /// <summary>
        /// Validates the on null.
        /// </summary>
        /// <typeparam name="V">
        /// Type of validating parameter
        /// </typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws when object is null
        /// </exception>
        private static void ValidateOnNull<V>(V obj, string name) where V : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{name} is null");
            }
        }

        /// <summary>
        /// Validates the borders.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="length">The length.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">invalid borders</exception>
        private static void ValidateBorders(int start, int end, int length)
        {
            if (start >= end || start < 0 || start >= length || end < 0 || end > length)
            {
                throw new ArgumentOutOfRangeException("invalid borders");
            }
        }
        #endregion
    }
}
