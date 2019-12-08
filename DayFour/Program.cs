using DayFour.Model;
using System;

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
