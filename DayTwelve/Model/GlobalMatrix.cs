using System;
using System.Text.RegularExpressions;

namespace DayTwelve.Model
{
    public class GlobalMatrix
    {
        public const int DIMENSION = 3;

        public int[][] Coordinates { get; set; }
        public int Size { get; set; }

        public GlobalMatrix(int size)
        {
            Size = size;

            Coordinates = new int[DIMENSION][];

            for (int i = 0; i < DIMENSION; i++) { Coordinates[i] = new int[Size]; }
        }

        public GlobalMatrix(int size, string[] input, string pattern) : this(size)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            for (int i = 0; i < size; i++)
            {
                if (!Regex.IsMatch(input[i], pattern)) throw new ArgumentException($"{input} does not match the expected pattern.");

                var match = Regex.Match(input[i], pattern);

                if (!match.Groups.ContainsKey("X") || !match.Groups.ContainsKey("Y") || !match.Groups.ContainsKey("Z"))
                    throw new ArgumentException($"{input} and {pattern} does not provide the required data.");

                Coordinates[0][i] = int.Parse(match.Groups["X"].Value);
                Coordinates[1][i] = int.Parse(match.Groups["Y"].Value);
                Coordinates[2][i] = int.Parse(match.Groups["Z"].Value);
            }
        }

        public ulong GetHash(int direction)
        {
            ulong hash = 0;

            for (int i = 0; i < Size; i++)
            {
#pragma warning disable CS0675 // Bitwise-or operator used on a sign-extended operand; consider casting to a smaller unsigned type first
                hash |= (ulong)((Coordinates[direction][i] & 0xff) << i * 8);
#pragma warning restore CS0675 // Bitwise-or operator used on a sign-extended operand; consider casting to a smaller unsigned type first
            }

            return hash;
        }
    }
}
