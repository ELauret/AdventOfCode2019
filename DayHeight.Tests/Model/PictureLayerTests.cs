using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayHeight.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayHeight.Model.Tests
{
    [TestClass()]
    public class PictureLayerTests
    {
        [DataTestMethod()]
        [DataRow(2, "123456", 0)]
        [DataRow(2, "789012", 1)]
        public void CountOfZeroDigitsTest(int height,  string encodedLayer, int expectedCount)
        {
            var layer = new PictureLayer(height, new List<char>(encodedLayer));

            Assert.AreEqual(height, layer.Rows.Length);
            Assert.AreEqual(expectedCount, layer.CountOfZeroDigits());
        }
    }
}