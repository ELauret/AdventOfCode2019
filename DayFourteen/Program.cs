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

                var reactor = new Reactor(reactions);
                Console.WriteLine(reactor.RequiredToProduce("ORE", "FUEL", 1));
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
