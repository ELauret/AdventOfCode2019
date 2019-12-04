using System;
using System.IO;
using System.Linq;
using MoreLinq;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"What is the lowest boundary of the range?");
            var minimum = int.Parse(Console.ReadLine());

            Console.WriteLine($"What is the highest boundary of the range?");
            var maximum = int.Parse(Console.ReadLine());


            // Count of numbers within range with increasing digits
            var count = Enumerable.Range(minimum, maximum - minimum + 1)
                .Where(n => n.ToString().Window(2).All(w => w[0] <= w[1])).Count();
            Console.WriteLine(count);

            // Count of numbers within range with strictly increasing digits
            count = Enumerable.Range(minimum, maximum - minimum + 1)
                .Where(n => n.ToString().Window(2).All(w => w[0] < w[1])).Count();
            Console.WriteLine(count);

            // Count of numbers within range with increasing digits and at least a pair of adjacent and identical digits
            count = Enumerable.Range(minimum, maximum - minimum + 1)
                .Where(n => n.ToString().Window(2).All(w => w[0] <= w[1]))
                .Where(n => n.ToString().Window(2).Any(w => w[0] == w[1])).Count();
            Console.WriteLine(count);

            // Count of numbers within range with increasing digits and at least an exact pair of adjacent and identical digits
            count = Enumerable.Range(minimum, maximum - minimum + 1)
                .Where(n => n.ToString().Window(2).All(w => w[0] <= w[1]))
                .Where(n => n.ToString().GroupAdjacent(d => d).Any(g => g.Count() == 2)).Count();
            Console.WriteLine(count);
        }
    }
}
