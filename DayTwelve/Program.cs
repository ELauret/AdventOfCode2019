using DayTwelve.Model;
using System;
using System.IO;
using System.Linq;

namespace DayTwelve
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = $"Resources/input.txt";

            try
            {
                if (!File.Exists(path)) throw new FileNotFoundException(path);

                var lines = File.ReadAllLines(path);

                if (!lines.Any()) throw new Exception($"File {path} is empty.");

                var system = new JupiterSystem(lines);
                var totalEnergy = system.UpdateSystem(1000);
                
                Console.WriteLine(totalEnergy);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
            }
        }
    }
}
