using System;
using System.IO;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using FourLeggedHead.IO;
using System.Collections.Generic;

namespace DaySixteen
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"Resources/input.txt";

            try
            {
                var lines = FileReader.ReadAllLines(path);

                var inputArray = lines.ElementAt(0).ToCharArray().Select(c => double.Parse(c.ToString()));

                // Part I

                var inputVector = Vector<double>.Build.DenseOfEnumerable(inputArray);
                var dimension = inputArray.Count();

                var matrix = Matrix<double>.Build.Dense(dimension, dimension);
                for (int i = 1; i < dimension + 1; i++)
                {
                    var patternQueue = new Queue<int>(new int[] { 0, 1, 0, -1 });

                    var patternValue = int.MinValue;
                    for (int j = 0; j < dimension + 1; j++)
                    {
                        if (j % i == 0)
                        {
                            patternValue = patternQueue.Dequeue();
                            patternQueue.Enqueue(patternValue);
                        }

                         if (j != 0) matrix[i - 1, j - 1] = patternValue;
                    }
                }

                //for (int i = 0; i < dimension; i++)
                //{
                //    Console.WriteLine(string.Join(' ', matrix.ToRowArrays()[i]
                //        .Select(v => (v == 0 ? "'" : ((int)v).ToString()).PadLeft(3))));
                //}

                for (int i = 0; i < 100; i++)
                {
                    var outputVector = matrix * inputVector;
                    inputVector = Vector<double>.Build.DenseOfEnumerable(outputVector.ToArray().Select(c => Math.Abs(c % 10)));
                }
                Console.WriteLine(string.Join(null, inputVector.ToArray().Take(8)));

                // Part II

                var offset = int.Parse(string.Join(null,inputArray.Take(7)));

                var inputList = new List<int>();
                for (int i = 0; i < 10000; i++) inputList.AddRange(inputArray.Select(ipt => (int)ipt));

                inputList = inputList.Skip(offset).ToList();

                for (int i = 0; i < 100; i++)
                {
                    for (int j = inputList.Count - 1; j >= 0; j--)
                    {
                        inputList[j] = Math.Abs(inputList[j] + (j < inputList.Count - 1 ? inputList[j+1] : 0)) % 10;
                    }
                }
                Console.WriteLine(string.Join(null, inputList.Take(8)));
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }
        }
    }
}
