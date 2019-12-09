using DayFive.Model;
using System;
using System.IO;
using System.Linq;

namespace DayNine
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
                var inputCode = lines[0].Split(",").Select(long.Parse);

                var computer = new IntcodeComputer(inputCode);

                Console.WriteLine($"What is the input?");
                var input = new long[] { int.Parse(Console.ReadLine()) };

                long output = long.MinValue;
                var status = computer.RunProgram(input, ref output);
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
