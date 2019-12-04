using System;
using System.IO;
using System.Linq;
using DayFour.Model;
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

            Console.WriteLine(NumbersCounter.WithIncreasingDigits(minimum, maximum));
            Console.WriteLine(NumbersCounter.WithStrictlyIncreasingDigits(minimum, maximum));
            Console.WriteLine(NumbersCounter.WithIncreasingDigitsAdjacentIdenticalPair(minimum, maximum));
            Console.WriteLine(NumbersCounter.WithIncreasingDigitsExactAdjacentIdenticalPair(minimum, maximum));
        }
    }
}
