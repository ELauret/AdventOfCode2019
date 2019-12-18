using System;
using System.IO;
using System.Linq;
using DayEighteen.Model;
using FourLeggedHead.IO;

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
                map.BuildTree(map.Locations.Values.First(l => l.Type == LocationType.Entrance));
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }
        }
    }
}
