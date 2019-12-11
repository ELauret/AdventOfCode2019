using DayTen.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DayTen.Model.Tests
{
    [TestClass()]
    public class AsteroidTests
    {
        #region CountAsteroidsWithDirectLineOfSight() Tests

        [DataTestMethod()]
        [DataRow(new string[] { ".#..#", ".....", "#####", "....#", "...##" }, 3, 4, 8)]
        [DataRow(new string[] { "......#.#.", "#..#.#....", "..#######.", ".#.#.###..",
            ".#..#.....", "..#....#.#", "#..#....#.", ".##.#..###", "##...#..#.", ".#....####" }, 5, 8, 33)]
        [DataRow(new string[] {"#.#...#.#.", ".###....#.", ".#....#...", "##.#.#.#.#",
            "....#.#.#.", ".##..###.#", "..#...##..", "..##....##", "......#...", ".####.###."}, 1, 2, 35)]
        [DataRow(new string[] { ".#..#..###", "####.###.#", "....###.#.", "..###.##.#",
            "##.##.#.#.", "....###..#", "..#.#..#.#", "#..#.#.###", ".##...##.#", ".....#.#.." }, 6, 3, 41)]
        [DataRow(new string[] { ".#..##.###...#######","##.############..##.",".#.######.########.#",".###.#######.####.#.",
            "#####.##.#.##.###.##","..#####..#.#########","####################","#.####....###.#.#.##",
            "##.#################","#####.##.###..####..","..######..##.#######","####.##.####...##..#",
            ".#####..#.######.###","##...#.##########...","#.##########.#######",".####.#.###.###.#.##",
            "....##.##.###..#####",".#.#.###########.###","#.#.#.#####.####.###","###.##.####.##.#..##"}, 11, 13, 210)]
        public void CountAsteriodsWithDirectLineOfSightTest(string[] mapFile, int xAsteroid, int yAsteroid, int expectedCount)
        {
            var map = new Map(mapFile);
            var asteroid = new Asteroid(xAsteroid, yAsteroid);

            var count = asteroid.CountAsteroidsWithDirectLineOfSight(map);

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountAsteriodsWithDirectLineOfSightWithNullMapTest()
        {
            new Asteroid().CountAsteroidsWithDirectLineOfSight(null);
        }

        #endregion

        #region IsAlignedWith() Tests

        [DataTestMethod()]
        [DataRow(new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { 3, 0 })]
        [DataRow(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 4, 4 })]
        [DataRow(new int[] { 0, 0 }, new int[] { 1, 2 }, new int[] { 3, 6 })]
        public void IsAlignedWithTestTrue(int[] firstAsteroidCoordinates,
            int[] secondAsteroidCoordinates, int[] thirdAsteroidCoordinates)
        {
            var firstAsteroid = new Asteroid(firstAsteroidCoordinates[0], firstAsteroidCoordinates[1]);
            var secondAsteroid = new Asteroid(secondAsteroidCoordinates[0], secondAsteroidCoordinates[1]);
            var thirdAsteroid = new Asteroid(thirdAsteroidCoordinates[0], thirdAsteroidCoordinates[1]);

            Assert.IsTrue(firstAsteroid.IsAlignedWith(secondAsteroid, thirdAsteroid));
            Assert.IsTrue(secondAsteroid.IsAlignedWith(firstAsteroid, thirdAsteroid));
            Assert.IsTrue(thirdAsteroid.IsAlignedWith(firstAsteroid, secondAsteroid));
        }

        [DataTestMethod()]
        [DataRow(new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { 2, 1 })]
        [DataRow(new int[] { 0, 0 }, new int[] { 2, 1 }, new int[] { 1, 1 })]
        [DataRow(new int[] { 0, 0 }, new int[] { 2, 0 }, new int[] { -3, -1 })]
        public void IsAlignedWithTestFalse(int[] firstAsteroidCoordinates,
           int[] secondAsteroidCoordinates, int[] thirdAsteroidCoordinates)
        {
            var firstAsteroid = new Asteroid(firstAsteroidCoordinates[0], firstAsteroidCoordinates[1]);
            var secondAsteroid = new Asteroid(secondAsteroidCoordinates[0], secondAsteroidCoordinates[1]);
            var thirdAsteroid = new Asteroid(thirdAsteroidCoordinates[0], thirdAsteroidCoordinates[1]);

            Assert.IsFalse(firstAsteroid.IsAlignedWith(secondAsteroid, thirdAsteroid));
            Assert.IsFalse(secondAsteroid.IsAlignedWith(firstAsteroid, thirdAsteroid));
            Assert.IsFalse(thirdAsteroid.IsAlignedWith(firstAsteroid, secondAsteroid));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsAlignedWithNullLocationsThrowExeption()
        {
            new Asteroid().IsAlignedWith(null, null);
        }

        #endregion

        #region GetRangeX() and GetRangeY() Tests

        [DataTestMethod()]
        [DataRow(new int[] { 11, 2 }, new int[] { 3, 7 }, 3, 11)]
        [DataRow(new int[] { 4, 17 }, new int[] { 8, 5 }, 4, 8)]
        public void GetRangeXTestSucceed(int[] firstAsteroidCoordinates,
            int[] secondAsteroidCoordinates, int expectedMinX, int expectedMaxX)
        {
            var firstAsteroid = new Asteroid(firstAsteroidCoordinates[0], firstAsteroidCoordinates[1]);
            var secondAsteroid = new Asteroid(secondAsteroidCoordinates[0], secondAsteroidCoordinates[1]);

            var range = Asteroid.GetRangeX(firstAsteroid, secondAsteroid);

            Assert.AreEqual(expectedMinX, range.Min);
            Assert.AreEqual(expectedMaxX, range.Max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetRangeXWithNullAsteroidThrowException()
        {
            Asteroid.GetRangeX(null, null);
        }


        [DataTestMethod()]
        [DataRow(new int[] { 11, 2 }, new int[] { 3, 7 }, 2, 7)]
        [DataRow(new int[] { 4, 17 }, new int[] { 8, 5 }, 5, 17)]
        public void GetRangeYTestSucceed(int[] firstAsteroidCoordinates,
            int[] secondAsteroidCoordinates, int expectedMinY, int expectedMaxY)
        {
            var firstAsteroid = new Asteroid(firstAsteroidCoordinates[0], firstAsteroidCoordinates[1]);
            var secondAsteroid = new Asteroid(secondAsteroidCoordinates[0], secondAsteroidCoordinates[1]);

            var range = Asteroid.GetRangeY(firstAsteroid, secondAsteroid);

            Assert.AreEqual(expectedMinY, range.Min);
            Assert.AreEqual(expectedMaxY, range.Max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetRangeYWithNullAsteroidThrowException()
        {
            Asteroid.GetRangeY(null, null);
        }

        #endregion
    }
}