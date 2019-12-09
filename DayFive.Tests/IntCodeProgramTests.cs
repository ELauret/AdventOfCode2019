using DayFive.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
            var output = long.MinValue;
            program.RunProgram(new long[] { 0 }, ref output);

            CollectionAssert.AreEquivalent(expectedOutputCode, program.Memory.Select(e => (int)e).ToList());
        }

        [DataTestMethod]
        [DataRow(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 5, 0)]
        [DataRow(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 1)]
        [DataRow(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 12, 0)]
        [DataRow(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 5, 1)]
        [DataRow(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 5, 0)]
        [DataRow(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 8, 1)]
        [DataRow(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 12, 0)]
        [DataRow(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 5, 1)]
        [DataRow(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 0, 0)]
        [DataRow(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 5, 1)]
        [DataRow(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 0, 0)]
        [DataRow(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 5, 1)]
        [DataRow(new long[] { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }, 5, 999)]
        [DataRow(new long[] { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }, 8, 1000)]
        [DataRow(new long[] { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }, 13, 1001)]
        [DataRow(new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 },
            null, 99)]
        [DataRow(new long[] { 104, 1125899906842624, 99 }, null, 1125899906842624)]
        public void TestRunProgramOutputSuccessfuly(long[] inputCode, int? input, long expectedOutput)
        {
            var program = new IntcodeComputer(inputCode);
            var output = long.MinValue;
            var inputs = input == null ? null : new long[] { (int)input };
            var status = program.RunProgram(inputs, ref output);

            Assert.AreEqual(ProgramStatus.Terminated, status);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestRunProgramOutputSixteenDigitsNumber()
        {
            var program = new IntcodeComputer(new int[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 });
            var output = long.MinValue;
            var status = program.RunProgram(null, ref output);

            Assert.AreEqual(ProgramStatus.Terminated, status);
            Assert.AreEqual(16, output.ToString().Length);
        }
    }
}
