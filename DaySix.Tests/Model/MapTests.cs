using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaySix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaySix.Model.Tests
{
    [TestClass()]
    public class MapTests
    {
        [TestMethod()]
        public void TotalNumberOfDirectAndIndirectOrbitsTest()
        {
            var mapDescriptor = new string[]
            { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" };

            var map = new Map(mapDescriptor, "COM");
            var result = map.TotalNumberOfDirectAndIndirectOrbits();

            Assert.AreEqual(42, result);
        }
    }
}