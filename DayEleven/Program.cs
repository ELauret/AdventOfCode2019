using DayEleven.Model;
using System;
using System.IO;
using System.Linq;

namespace DayEleven
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

                var hull = new Hull();
                var paintingRobot = new PaintingRobot(inputCode);
                paintingRobot.PaintHull(hull, PaintColor.Black);
                hull.ViewHull();

                Console.WriteLine(hull.Panels.Count);

                hull = new Hull();
                paintingRobot.Brain.Reset();
                paintingRobot.PaintHull(hull, PaintColor.White);
                hull.ViewHull();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
