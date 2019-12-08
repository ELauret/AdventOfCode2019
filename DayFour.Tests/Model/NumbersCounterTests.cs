using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayFour.Model.Tests
{
    [TestClass()]
    public class NumbersCounterTests
    {
        [DataTestMethod]
        [DataRow(10, 99, 45)]
        [DataRow(100, 999, 165)]
        [DataRow(1000, 9999, 495)]
        public void WithIncreasingDigitsTest(int minimum, int maximum, int expectedCount)
        {
            var count = NumbersCounter.WithIncreasingDigits(minimum, maximum);
            Assert.AreEqual(expectedCount, count);
        }

        [DataTestMethod]
        [DataRow(10, 99, 36)]
        [DataRow(100, 999, 84)]
        [DataRow(1000, 9999, 126)]
        public void WithStrictlyIncreasingDigitsTest(int minimum, int maximum, int expectedCount)
        {
            var count = NumbersCounter.WithStrictlyIncreasingDigits(minimum, maximum);
            Assert.AreEqual(expectedCount, count);
        }

        [DataTestMethod]
        [DataRow(10, 99, 9)]
        [DataRow(100, 999, 81)]
        [DataRow(1000, 9999, 369)]
        public void WithIncreasingDigitsAdjacentIdenticalPair(int minimum, int maximum, int expectedCount)
        {
            var count = NumbersCounter.WithIncreasingDigitsAdjacentIdenticalPair(minimum, maximum);
            Assert.AreEqual(expectedCount, count);
        }

        [DataTestMethod]
        [DataRow(10, 99, 9)]
        [DataRow(100, 999, 72)]
        public void WithIncreasingDigitsExactAdjacentIdenticalPair(int minimum, int maximum, int expectedCount)
        {
            var count = NumbersCounter.WithIncreasingDigitsExactAdjacentIdenticalPair(minimum, maximum);
            Assert.AreEqual(expectedCount, count);
        }
    }
}