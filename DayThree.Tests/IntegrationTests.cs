using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayThree.Model;
using System.Linq;

namespace DayThree.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [DataTestMethod]
        [DataRow("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void ManhattanDistanceOfClosestIntersection(string firstWireSections, string secondWireSections, int expectedDistance)
        {
            var firstWire = new Wire(firstWireSections);
            var secondWire = new Wire(secondWireSections);
            var origin = new Point(0, 0);

            var intersections = firstWire.GetListOfIntersectionsWith(secondWire);
            intersections.Remove(origin);

            Assert.AreEqual(expectedDistance, intersections.Min(p => p.ManhattanDistanceTo(origin)));
        }

        [DataTestMethod]
        [DataRow("R8,U5,L5,D3", "U7,R6,D4,L4", 30)]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void FewestStepsToReachAnIntersection(string firstWireSections, string secondWireSections, int expectedSteps)
        {
            var firstWire = new Wire(firstWireSections);
            var secondWire = new Wire(secondWireSections);
            var origin = new Point(0, 0);

            var intersections = firstWire.GetListOfIntersectionsWith(secondWire);
            intersections.Remove(origin);

            var fewestSteps = intersections.Select(p => p.StepsToReachPoint = firstWire.Path.Find(q => q == p).StepsToReachPoint
                        + secondWire.Path.Find(q => q == p).StepsToReachPoint).Min();

            Assert.AreEqual(expectedSteps, fewestSteps);
        }
    }
}
