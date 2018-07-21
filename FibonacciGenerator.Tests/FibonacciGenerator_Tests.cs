using System;
using System.Collections.Generic;
using System.Numerics;
using FibonacciLib;
using NUnit.Framework;

namespace FibonacciGenerator.Tests
{
    [TestFixture]
    public class FibonacciGenerator_Tests
    {
        [TestCase(5, new int[] {0, 1, 1, 2, 3})]
        [TestCase(1, new int[] {0})]
        [TestCase(2, new int[] {0, 1})]
        [TestCase(10, new int[] {0, 1, 1, 2, 3, 5, 8, 13, 21, 34})]
        public void Can_Generate_Fibonacci(int n, int[] expected)
        {
            IEnumerable<long> result = Fibonacci.Generate(n);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(93)]
        public void Throws_When_N_Is_Non_Positive(int n)
            => Assert.Throws<ArgumentOutOfRangeException>(() => Fibonacci.Generate(n));
    }
}
