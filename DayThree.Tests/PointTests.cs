using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayThree.Model;

namespace DayThree.Tests
{
    [TestClass]
    public class PointTests
    {
        [DataTestMethod]
        [DataRow(1,1,4,4,6)]
        [DataRow(1, 2, 4, -7, 12)]
        public void ManhattanDistanceBetweenPointAndCoordinated(int x1, int y1, int x2, int y2, int expectedDistance)
        {
            var p = new Point(x1, y1);
            Assert.AreEqual(expectedDistance, p.ManhattanDistanceTo(x2, y2));
        }
    }
}
