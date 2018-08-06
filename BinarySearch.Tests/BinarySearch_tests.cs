using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchLib;
using NUnit.Framework;

namespace BinarySearch_Tests
{
    [TestFixture]
    public class BinarySearch_Tests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 1, 1, 4, 5 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 1, 1, 4, 5, 6 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 5 }, 5, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, ExpectedResult = null)]
        [TestCase(new int[] { 1, 2, 3, 4, 7 }, 6, ExpectedResult = null)]
        [TestCase(new int[] {}, 2, ExpectedResult = null)]
        public int? Can_Search_On_Int(int[] array, int item)
        {
            int compare(int a, int b)
            {
                if (a > b) return 1;
                if (a < b) return -1;
                return 0;
            }

            return BinarySearch<int>.Search(array, item, compare);
        }

        [Test]
        public void Throws_ArgumentNull_On_Null_Array()
        {
            Assert.Throws<ArgumentNullException>(() =>
                BinarySearch<int>.Search(null, 1, Comparer<int>.Default.Compare));
        }

        [Test]
        public void Throws_ArgumentNull_On_Null_Comparison()
        {
            Assert.Throws<ArgumentNullException>(() =>
                BinarySearch<int>.Search(new int[]{}, 1, (IComparer<int>)null));
        }

        [TestCase(1, 6)]
        [TestCase(-1, 3)]
        [TestCase(4, 3)]
        [TestCase(-2, -1)]
        [TestCase(7, 8)]
        public void Throws_When_Invalid_Borders(int start, int end)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                BinarySearch<int>.Search(new int[] {1, 2, 3, 4, 5}, 1, Comparer<int>.Default.Compare, start, end));
        }
    }
}
