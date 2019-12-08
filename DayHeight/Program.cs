using DayHeight.Model;
using System;
using System.IO;
using System.Linq;

namespace DayHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = $"Resources/input.txt";

            try
            {
                if (!File.Exists(path)) throw new FileNotFoundException(path);

                var lines = File.ReadAllLines(path);

                if (!lines.Any()) throw new Exception($"File {path} is empty.");

                var width = 25;
                var height = 6;
                var picture = new Picture(width, height, lines[0]);

                var layer = picture.GetLayerWithFewestZeroDigits();
                Console.WriteLine(layer.LayerCheck());

                Console.WriteLine();

                var finalPicture = picture.Decode();
                finalPicture.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
