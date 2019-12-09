using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DayHeight.Model.Tests
{
    [TestClass()]
    public class LayerRowTests
    {
        [DataTestMethod()]
        [DataRow("123", 0)]
        [DataRow("012", 1)]
        [DataRow("102084105", 3)]
        public void CountOfZeroDigitsTest(string encodedRow, int expectedCount)
        {
            var row = new LayerRow(new List<char>(encodedRow));

            Assert.AreEqual(expectedCount, row.CountOfZeroDigits());
        }
    }
}