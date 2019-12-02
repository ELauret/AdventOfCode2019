using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DayTwo.Model;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = $"Resources/input.txt";

            try
            {
                if (!File.Exists(path)) throw new FileNotFoundException();
                var lines = File.ReadAllLines(path);

                if (lines.Length == 0) throw new Exception($"File is empty.");
                var inputCode = lines[0].Split(",").Select(int.Parse);

                Console.WriteLine(CalculateStatePartI(inputCode));
                Console.WriteLine(DetermineInputPhrasePartII(inputCode));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int CalculateStatePartI(IEnumerable<int> inputCode)
        {
            var computer = new IntcodeComputer(inputCode);

            computer.FixInputMemory(1, 12);
            computer.FixInputMemory(2, 2);

            computer.RunProgram();

            return computer.Memory[0];
        }

        private static int DetermineInputPhrasePartII(IEnumerable<int> inputCode)
        {
            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    var computer = new IntcodeComputer(inputCode);

                    computer.FixInputMemory(1, i);
                    computer.FixInputMemory(2, j);

                    computer.RunProgram();

                    if (computer.Memory[0] == 19690720)
                    {
                        return 100 * i + j;
                    }
                }
            }

            return int.MinValue;
        }
    }
}
