using DayOne.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayOne.Tests
{
    [TestClass]
    public class ModuleTests
    {
        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 654)]
        [DataRow(100756, 33583)]
        public void RequiredFuelForModuleSimple(int mass, int expectedFuel)
        {
            var module = new SpacecraftModule(mass, CalculationType.Simple);
            Assert.AreEqual(expectedFuel, module.RequiredFuel);
        }

        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 966)]
        [DataRow(100756, 50346)]
        public void RequiredFuelForModuleComplex(int mass, int expectedFuel)
        {
            var module = new SpacecraftModule(mass, CalculationType.Complex);
            Assert.AreEqual(expectedFuel, module.RequiredFuel);
        }
    }
}
