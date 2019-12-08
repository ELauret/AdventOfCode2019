using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayHeight.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayHeight.Model.Tests
{
    [TestClass()]
    public class PictureTests
    {
        [DataTestMethod()]
        [DataRow(3,2,"",2,1)]
        public void GetLayerWithFewestZeroDigitsTest(int width, int height, string encodedPicture, int expectedLayer, int expectedCount)
        {
            Assert.Fail();
        }
    }
}