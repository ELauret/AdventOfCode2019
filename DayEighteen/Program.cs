using System;
using System.IO;
using System.Linq;
using DayEighteen.Model;
using FourLeggedHead.IO;
using FourLeggedHead.Tools;

namespace DayEighteen
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"Resources/input.txt";

            try
            {
                var mapRows = FileReader.ReadAllLines(path);

                var map = new Map(mapRows);
                map.FixMapNearEntrance();
                var origin = map.Find(l => l.Type == LocationType.Entrance);

                var watch = System.Diagnostics.Stopwatch.StartNew();
                var resultBFE = GraphSolver.BreadthFirstExploration(map, origin);
                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);

                watch.Restart();
                var resultDFE = GraphSolver.DepthFirstExploration(map, origin);
                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);

                watch.Restart();
                map.RemoveAll(l => l.Type == LocationType.Wall);
                var distances = GraphSolver.GetShortestPathDijkstra(map, origin, null);
                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }
        }
    }
}
