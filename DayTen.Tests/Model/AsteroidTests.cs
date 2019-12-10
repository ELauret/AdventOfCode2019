using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayTen.Model;
using System;
using System.Collections.Generic;
using System.Text;
using DayTen.Model;

namespace DayTen.Model.Tests
{
    [TestClass()]
    public class AsteroidTests
    {
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

            var count = asteroid.CountAsteriodsWithDirectLineOfSight(map.Asteroids);

            Assert.AreEqual(expectedCount, count);
        }
    }
}