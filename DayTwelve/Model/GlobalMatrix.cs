using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace DayTwelve.Model
{
    public class GlobalMatrix
    {
        const int DIMENSION = 3;

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
                if(!Regex.IsMatch(input[i], pattern)) throw new ArgumentException($"{input} does not match the expected pattern.");

                var match = Regex.Match(input[i], pattern);

                if(!match.Groups.ContainsKey("X") || !match.Groups.ContainsKey("Y") || !match.Groups.ContainsKey("Z"))
                    throw new ArgumentException($"{input} and {pattern} does not provide the required data.");

                Coordinates[1][i] = int.Parse(match.Groups["X"].Value);
                Coordinates[2][i] = int.Parse(match.Groups["Y"].Value);
                Coordinates[3][i] = int.Parse(match.Groups["Z"].Value);
            }
        }
    }
}
