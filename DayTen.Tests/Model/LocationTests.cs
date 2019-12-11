using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayTen.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayTen.Model.Tests
{
    [TestClass()]
    public class LocationTests
    {
        #region BelongsTo() Tests

        [TestMethod()]
        public void LocationFromMapBelongsToTestTrue()
        {
            var map = new Map(new string[] { ".#..#", ".....", "#####", "....#", "...##" });
            var location = map.Locations[7];

            Assert.IsTrue(location.BelongsTo(map));
        }

        [TestMethod()]
        public void NewParameterlessLocationBelongsToTestTrue()
        {
            var map = new Map(new string[] { ".#..#", ".....", "#####", "....#", "...##" });
            var emptyLocation = new EmptyLocation(); // Creates a (0,0) empty location that does belong to map

            Assert.IsTrue(emptyLocation.BelongsTo(map));
        }

        [TestMethod()]
        public void OutsideMapLocationBelongsToTestFalse()
        {
            var map = new Map(new string[] { ".#..#", ".....", "#####", "....#", "...##" });
            var location = new EmptyLocation(50, 50);

            Assert.IsFalse(location.BelongsTo(map));
        }

        [TestMethod()]
        public void WrongsLocationTypeBelongsToTestFalse()
        {
            var map = new Map(new string[] { ".#..#", ".....", "#####", "....#", "...##" });
            var asteroid = new Asteroid(); // Creates a (0,0) asteroid that does belong to map because (0,0) is an empty location

            Assert.IsFalse(asteroid.BelongsTo(map));
        }

        [TestMethod()]
        public void NullMapBelongsToTestTrue()
        {
            var location = new EmptyLocation(12, 35);

            Assert.IsFalse(location.BelongsTo(null));
        }

        #endregion

        #region EqualsTo() Tests

        [TestMethod()]
        public void EmptyLocationsWithSameCoordinatesEqualsTestTrue()
        {
            var x = 12;
            var y = 35;
            var firstLocation = new EmptyLocation(x, y);
            var secondLocation = new EmptyLocation(x, y);

            Assert.IsTrue(firstLocation.Equals(secondLocation));
        }

        [TestMethod()]
        public void EmptyLocationsWithDifferentCoordinatesEqualsTestFalse()
        {
            var firstLocation = new EmptyLocation(12, 35);
            var secondLocation = new EmptyLocation(76,29);

            Assert.IsFalse(firstLocation.Equals(secondLocation));
        }

        [TestMethod()]
        public void LocationsWithDifferentTypesEqualsTestFalse()
        {
            var x = 12;
            var y = 35;
            var firstLocation = new EmptyLocation(x, y);
            var secondLocation = new Asteroid(x, y);

            Assert.IsFalse(firstLocation.Equals(secondLocation));
        }

        [TestMethod()]
        public void NullParameterEqualsTestFalse()
        {
            var location = new EmptyLocation(12, 35);

            Assert.IsFalse(location.Equals(null));
        }

        [TestMethod()]
        public void WrongTypeParameterEqualsTestFalse()
        {
            var location = new EmptyLocation(12, 35);

            Assert.IsFalse(location.Equals(56));
        }

        #endregion
    }
}