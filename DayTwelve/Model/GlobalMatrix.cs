using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DayTwelve.Model
{
    public class GlobalMatrix
    {
        public int[] X { get; set; }
        public int[] Y { get; set; }
        public int[] Z { get; set; }
        public int Size { get; set; }

        public GlobalMatrix(int size)
        {
            Size = size;

            X = new int[Size];
            Y = new int[Size];
            Z = new int[Size];
        }

        public GlobalMatrix(int size, string[] input, string pattern) : this(size)
        {
            for (int i = 0; i < size; i++)
            {
                if(!Regex.IsMatch(input[i], pattern)) throw new ArgumentException($"{input} does not match the expected pattern.");

                var match = Regex.Match(input[i], pattern);

                if(!match.Groups.ContainsKey("X") || !match.Groups.ContainsKey("Y") || !match.Groups.ContainsKey("Z"))
                    throw new ArgumentException($"{input} and {pattern} does not provide the required data.");

                X[i] = int.Parse(match.Groups["X"].Value);
                Y[i] = int.Parse(match.Groups["Y"].Value);
                Z[i] = int.Parse(match.Groups["Z"].Value);
            }
        }
    }
}
