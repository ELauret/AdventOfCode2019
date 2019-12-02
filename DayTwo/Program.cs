using System;
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

                var program = new IntcodeProgram(lines[0].Split(",").Select(int.Parse));

                program.FixCode(1, 12);
                program.FixCode(2, 2);

                program.Run();

                Console.WriteLine(program.Code[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
