namespace FibonacciLib
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>
    /// Fibonacci generator
    /// </summary>
    public static class Fibonacci
    {
        #region Private constants
        /// <summary>
        /// The maximum long fibonacci index
        /// </summary>
        private const int MaxLongFibonacciIndex = 92;
        #endregion

        #region Public API
        /// <summary>
        /// Generates a collection of n fibonacci numbers
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>The collection of n fibonacci numbers.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when n is non-positive or </exception>
        public static IEnumerable<long> Generate(int n)
        {
            if (n <= 0 || n > MaxLongFibonacciIndex)
            {
                throw  new ArgumentOutOfRangeException($"{nameof(n)} must be positive");
            }

            IEnumerable<long> Find()
            {
                (long a, long b) = (0, 1);

                while (n-- > 0)
                {
                    yield return a;
                    (a, b) = (b, a + b);
                }
            }

            return Find();
        }

        /// <summary>
        /// Generates a collection of n big integer fibonacci numbers
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">n</exception>
        public static IEnumerable<BigInteger> GenerateBigInteger(int n)
        {
            if (n <= 0 || n > MaxLongFibonacciIndex)
            {
                throw new ArgumentOutOfRangeException($"{nameof(n)} must be positive");
            }

            IEnumerable<BigInteger> Find()
            {
                (BigInteger a, BigInteger b) = (0, 1);

                while (n-- > 0)
                {
                    yield return a;
                    (a, b) = (b, a + b);
                }
            }

            return Find();
        }
        #endregion
    }
}
