using DayFive.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DayFive.Tests
{
    [TestClass]
    public class IntCodeProgramTests
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 0, 0, 0, 99 }, new int[] { 2, 0, 0, 0, 99 })]
        [DataRow(new int[] { 2, 3, 0, 3, 99 }, new int[] { 2, 3, 0, 6, 99 })]
        [DataRow(new int[] { 2, 4, 4, 5, 99, 0 }, new int[] { 2, 4, 4, 5, 99, 9801 })]
        [DataRow(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void TestRunProgramSuccessfuly(int[] inputCode, int[] expectedOutputCode)
        {
            var program = new IntcodeComputer(inputCode);

            program.RunProgram(0);

            Console.WriteLine("[{0}]", string.Join(", ", expectedOutputCode));
            Console.WriteLine("[{0}]", string.Join(", ", program.Memory));

            CollectionAssert.AreEquivalent(expectedOutputCode, program.Memory);
        }
    }
}
