using System;
using System.IO;
using System.Linq;
using DayFifteen.Model;
using FourLeggedHead.IO;

namespace DayFifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"Resources/input.txt";

            try
            {
                var lines = FileReader.ReadAllLines(path);

                var area = new Area();
                var droid = new RepairDroid(lines.ElementAt(0));
                droid.DiscoverNextFrom(area, null, null);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }
        }
    }
}
