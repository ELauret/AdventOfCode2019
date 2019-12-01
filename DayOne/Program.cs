using DayOne.Model;
using System;
using System.IO;

namespace DayOne
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

                var spacecraft = new Spacecraft();

                foreach (var line in lines)
                {
                    spacecraft.Modules.Add(new Module(int.Parse(line), CalculationType.Complex));
                }

                Console.WriteLine(spacecraft.RequiredFuel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
