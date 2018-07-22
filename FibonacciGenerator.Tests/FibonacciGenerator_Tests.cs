using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using FibonacciLib;
using NUnit.Framework;

namespace FibonacciGenerator.Tests
{
    [TestFixture]
    public class FibonacciGenerator_Tests
    {
        [Test]
        public void Can_Generate_BigInteger_Fibonacci()
        {
            const int assertions = 4;

            BigInteger[][] expected =
            {
                new BigInteger[]{0, 1, 1, 2, 3},
                new BigInteger[]{0},
                new BigInteger[]{0, 1},
                new BigInteger[]{0, 1, 1, 2, 3, 5, 8, 13, 21, 34}
            };

            for (int i = 0; i < assertions; i++)
            {
                CollectionAssert.AreEqual(expected[i], Fibonacci.GenerateBigInteger(expected[i].Length));
            }
        }

        [TestCase(500, ExpectedResult = 500)]
        [TestCase(1000, ExpectedResult = 1000)]
        [TestCase(10000, ExpectedResult = 10000)]
        public int Can_Generate_Big_Count_Of_Fibonaccies(int n)
            => Fibonacci.GenerateBigInteger(n).ToArray().Length;

        [TestCase(-1)]
        [TestCase(0)]
        public void Throws_When_N_Is_Non_Positive(int n)
            => Assert.Throws<ArgumentOutOfRangeException>(() => Fibonacci.GenerateBigInteger(n));
    }
}
