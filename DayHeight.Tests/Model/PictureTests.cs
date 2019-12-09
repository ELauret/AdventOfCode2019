using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayHeight.Model.Tests
{
    [TestClass()]
    public class PictureTests
    {
        [DataTestMethod()]
        [DataRow(3, 2, "123456789012", 0, 0)]
        public void GetLayerWithFewestZeroDigitsTest(int width, int height, string encodedPicture, int expectedLayer, int expectedCount)
        {
            var picture = new Picture(width, height, encodedPicture);
            var layer = picture.GetLayerWithFewestZeroDigits();

            Assert.AreEqual(expectedLayer, picture.Layers.FindIndex(l => l == layer));
            Assert.AreEqual(expectedCount, layer.CountOfZeroDigits());
        }
    }
}