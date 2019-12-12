using DayTwelve.Model;
using System;
using System.Collections.Generic;
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

                var watch = System.Diagnostics.Stopwatch.StartNew();

                var system = new JupiterSystem(lines);
                var totalEnergy = system.UpdateSystem(1000);
                Console.WriteLine(totalEnergy);

                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);

                watch.Restart();

                var globalSystem = new GlobalSystem(lines);
                Console.WriteLine(globalSystem.UpdateSystem(1000));

                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
            }
        }
    }
}
