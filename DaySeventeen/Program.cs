using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DaySeventeen.Model;
using FourLeggedHead.IO;
using FourLeggedHead.Model;

namespace DaySeventeen
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"Resources/input.txt";

            try
            {
                var lines = FileReader.ReadAllLines(path);

                // Part I

                var ascii = new IntcodeComputer(lines.ElementAt(0));
                ascii.RunProgram(null);

                foreach (var output in ascii.Output)
                {
                    Console.Write((char)output);
                }

                var x = 0;
                var y = 0;
                var map = new List<Location>();

                foreach (var output in ascii.Output)
                {
                    switch (output)
                    {
                        case long o when (o == '.' || o == 'X'):
                            map.Add(new Location(x, y, LocationType.Empty));
                            x++;
                            break;
                        case long o when (new long[] { '#', '<', '>', 'v', '^' }).Contains(o):
                            map.Add(new Location(x, y, LocationType.Path));
                            x++;
                            break;
                        case '\n':
                            x = 0;
                            y++;
                            break;
                        default:
                            break;
                    }
                }

                var sumOfAlignmentParameters = 0;

                foreach (var location in map)
                {
                    if (location.Type == LocationType.Path && CountPathAround(map, location) == 4)
                    {
                        location.Type = LocationType.Intersection;
                        Console.WriteLine(location.ToString());

                        sumOfAlignmentParameters += location.X * location.Y;
                    }
                }

                Console.WriteLine(map.Count(l => l.Type == LocationType.Intersection));
                Console.WriteLine(sumOfAlignmentParameters);

                // Part II

                var robot = new IntcodeComputer(lines.ElementAt(0));
                robot.FixInputMemory(0, 2);

                var movements = FileReader.ReadAllLines(@"Resources/MovementsAlpha.txt");
                var inputs = new List<long>();
                var debug = 'n';

                foreach (var line in movements)
                {
                    inputs.AddRange(line.ToCharArray().Select(c => (long)c).Append(10));
                }

                robot.RunProgram(inputs.Append(debug).Append(10));

                if (debug == 'y')
                {
                    foreach (var output in robot.Output)
                    {
                        Console.Write((char)output);
                    } 
                }

                Console.WriteLine(robot.Output.Last());
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private static int CountPathAround(IEnumerable<Location>map, Location location)
        {
            var count = map.Count(l => l.X == location.X && l.Y == location.Y - 1 && l.Type == LocationType.Path);
            count += map.Count(l => l.X == location.X && l.Y == location.Y + 1 && l.Type == LocationType.Path);
            count += map.Count(l => l.X == location.X - 1 && l.Y == location.Y && l.Type == LocationType.Path);
            return count += map.Count(l => l.X == location.X + 1 && l.Y == location.Y && l.Type == LocationType.Path);
        }
    }
}

