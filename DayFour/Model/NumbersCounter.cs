using MoreLinq;
using System.Linq;

namespace DayFour.Model
{
    public static class NumbersCounter
    {
        /// <summary>
        /// Count of numbers within range with increasing digits
        /// </summary>
        /// <param name="minimum">Lowest boundary of the range</param>
        /// <param name="maximum">Highest boundary of the range</param>
        /// <returns></returns>
        public static int WithIncreasingDigits(int minimum, int maximum)
        {
            return Enumerable.Range(minimum, maximum - minimum + 1)
                            .Where(n => n.ToString().Window(2).All(w => w[0] <= w[1])).Count();
        }


        /// <summary>
        /// Count of numbers within range with strictly increasing digits
        /// </summary>
        /// <param name="minimum">Lowest boundary of the range</param>
        /// <param name="maximum">Highest boundary of the range</param>
        /// <returns></returns>
        public static int WithStrictlyIncreasingDigits(int minimum, int maximum)
        {
            return Enumerable.Range(minimum, maximum - minimum + 1)
                .Where(n => n.ToString().Window(2).All(w => w[0] < w[1])).Count();
        }

        /// <summary>
        /// Count of numbers within range with increasing digits and at least a pair of adjacent and identical digits
        /// </summary>
        /// <param name="minimum">Lowest boundary of the range</param>
        /// <param name="maximum">Highest boundary of the range</param>
        /// <returns></returns>
        public static int WithIncreasingDigitsAdjacentIdenticalPair(int minimum, int maximum)
        {
            return Enumerable.Range(minimum, maximum - minimum + 1)
                            .Where(n => n.ToString().Window(2).All(w => w[0] <= w[1]))
                            .Where(n => n.ToString().Window(2).Any(w => w[0] == w[1])).Count();
        }

        /// <summary>
        /// Count of numbers within range with increasing digits and at least an exact pair of adjacent and identical digits
        /// </summary>
        /// <param name="minimum">Lowest boundary of the range</param>
        /// <param name="maximum">Highest boundary of the range</param>
        /// <returns></returns>
        public static int WithIncreasingDigitsExactAdjacentIdenticalPair(int minimum, int maximum)
        {
            return Enumerable.Range(minimum, maximum - minimum + 1)
                            .Where(n => n.ToString().Window(2).All(w => w[0] <= w[1]))
                            .Where(n => n.ToString().GroupAdjacent(d => d).Any(g => g.Count() == 2)).Count();
        }
    }
}
