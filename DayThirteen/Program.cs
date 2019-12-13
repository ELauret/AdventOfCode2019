using System;
using System.IO;
using System.Linq;
using DayThirteen.Model;

namespace DayThirteen
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"Resources\input.txt";

            try
            {
                if (!File.Exists(path)) throw new FileNotFoundException(path);

                var lines = File.ReadAllLines(path);

                if (!lines.Any()) throw new Exception($"The file {path} is empty.");

                var arcadeCabinet = new ArcadeCabinet(lines[0]);
                arcadeCabinet.UpdateDisplay(null);

                Console.WriteLine(arcadeCabinet.Screen.Count(t => t.Type == TileType.Block));

                arcadeCabinet = new ArcadeCabinet(lines[0]);
                arcadeCabinet.PlayGame();

                Console.WriteLine($"Finale Score: {arcadeCabinet.Score}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
