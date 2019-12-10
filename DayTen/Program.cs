using DayTen.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayTen
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = $"Resources/input.txt";

            try
            {
                if (!File.Exists(path)) throw new FileNotFoundException("path");

                var lines = File.ReadAllLines(path);

                if (!lines.Any()) throw new Exception($"File {path} is empty");

                var map = new Map(lines);

                IAsteroid bestAsteroid;
                Console.WriteLine(map.MaxCountOfDetectableAteroids(out bestAsteroid));

                var lazer = new RotatingLazer(bestAsteroid);
                var lastVaporizedAsteroid = lazer.VaporizeAsteroids(map, 200);

                Console.WriteLine(100 * lastVaporizedAsteroid.X + lastVaporizedAsteroid.Y);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
