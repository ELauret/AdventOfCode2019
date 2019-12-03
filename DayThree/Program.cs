using DayThree.Model;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayThree
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

                if (lines.Length == 0) throw new Exception(@"File is empty.");

                var firstWire = new Wire(lines[0]);
                var secondWire = new Wire(lines[1]);

                var origin = new Point(0, 0);

                var intersectionPoints = firstWire.GetListOfIntersectionsWith(secondWire);
                intersectionPoints.Remove(origin);

                Console.WriteLine(intersectionPoints.Min(p => p.ManhattanDistanceTo(origin)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
