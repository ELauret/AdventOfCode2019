﻿using System;
using System.IO;
using System.Linq;
using DaySeven.Model;

namespace DaySeven
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = $"Resources/input.txt";

            try
            {
                if (!File.Exists(path)) throw new FileNotFoundException();
                var lines = File.ReadAllLines(path);

                if (lines.Length == 0) throw new Exception($"File is empty.");
                var inputCode = lines[0].Split(",").Select(int.Parse);

                var amplifyingStack = new AmplifyingStack(5, inputCode);
                var optimalConfig = amplifyingStack.Optimize(0);

                Console.WriteLine(optimalConfig.output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}