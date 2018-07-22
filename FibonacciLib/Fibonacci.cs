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
        #region Public API
        /// <summary>
        /// Generates a collection of n big integer fibonacci numbers
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">n</exception>
        public static IEnumerable<BigInteger> GenerateBigInteger(int n)
        {
            if (n <= 0)
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
