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

                globalSystem = new GlobalSystem(lines);

                var frequencyX = globalSystem.FindFrequencyOfOneDirection(0);
                Console.WriteLine($"Frequency along X: {frequencyX}");

                var frequencyY = globalSystem.FindFrequencyOfOneDirection(1);
                Console.WriteLine($"Frequency along Y: {frequencyY}");

                var frequencyZ = globalSystem.FindFrequencyOfOneDirection(2);
                Console.WriteLine($"Frequency along Z: {frequencyZ}");

                var globalFrequency = GlobalSystem.LeastCommonMultiplier(frequencyZ,
                                    GlobalSystem.LeastCommonMultiplier(frequencyY, frequencyX));
                Console.WriteLine($"System Frequency: {globalFrequency}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
            }
        }
    }
}
