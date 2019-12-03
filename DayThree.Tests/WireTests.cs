using DayThree.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayThree.Tests
{
    [TestClass]
    public class WireTests
    {
        [TestMethod]
        public void GetIntersectionsBetweenWires()
        {
            var firstWire = new Wire("R8,U5,L5,D3");
            var secondWire = new Wire("U7,R6,D4,L4");

            var intersections = firstWire.GetListOfIntersectionsWith(secondWire);

            CollectionAssert.Contains(intersections, new Point(3, 3));
            CollectionAssert.Contains(intersections, new Point(6, 5));
        }
    }
}
