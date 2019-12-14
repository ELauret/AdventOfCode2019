using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayTwelve.Model.Tests
{
    [TestClass()]
    public class JupiterMoonTests
    {
        [DataTestMethod()]
        [DataRow(new[] { 1, 2, 3 }, new[] { -2, 0, 3 }, new[] { -1, 2, 6 })]
        public void UpdatePositionTest(int[] initialPosition, int[] velocity, int[] expectedFinalPosition)
        {
            var moon = new JupiterMoon(initialPosition, velocity);
            moon.UpdatePosition();

            Assert.AreEqual(new Vector(expectedFinalPosition), moon.Position);
        }
    }
}