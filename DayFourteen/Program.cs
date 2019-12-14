//using DayFourteen.Model;
using System;
using System.IO;
using FourLeggedHead.IO;

namespace DayFourteen
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Resources/input.txt";

            try
            {
                var lines = FileReader.ReadAllLines(path);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
