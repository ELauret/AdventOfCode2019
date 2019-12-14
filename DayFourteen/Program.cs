using DayFourteen.Model;
using FourLeggedHead.IO;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayFourteen
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Resources/input.txt";

            try
            {
                var reactions = FileReader.ReadAllLines(path).Where(r => Regex.IsMatch(r, Reaction.REACTION_PATTERN));

                var watch = System.Diagnostics.Stopwatch.StartNew();

                var reactor = new Reactor(reactions);
                Console.WriteLine(reactor.RequiredToProduce("ORE", "FUEL", 1));

                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);

                reactor = new Reactor(reactions);
                Console.WriteLine(reactor.MaxFuelProducedWith(1000000000000));
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
