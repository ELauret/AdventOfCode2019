using DayFive.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MoreLinq;
using System.Threading;

namespace DayThirteen.Model
{
    public class ArcadeCabinet
    {
        public IntcodeComputer Brain{ get; set; }
        public List<Tile> Screen { get; set; }
        public int Score { get; set; }

        public ArcadeCabinet(string program)
        {
            Brain = new IntcodeComputer(program);

            Screen = new List<Tile>();
        }

        public ProgramStatus UpdateDisplay(IEnumerable<long> input)
        {
            Brain.Output.Clear();
            var brainStatus = Brain.RunProgram(input);

            var tileInputs = Brain.Output.Batch(3);

            foreach (var tileInput in tileInputs)
            {
                if ((int)tileInput.ElementAt(0) == -1 && (int)tileInput.ElementAt(1) == 0) Score = (int)tileInput.ElementAt(2);
                else
                {
                    var x = (int)tileInput.ElementAt(0);
                    var y = (int)tileInput.ElementAt(1);
                    var type = (TileType)Enum.ToObject(typeof(TileType), tileInput.ElementAt(2));

                    var tile = Screen.Count > 0 ? Screen.FirstOrDefault(t => (t.X == x) && (t.Y == y)) : null;

                    if (tile == null) Screen.Add(new Tile(x, y, type));
                    else tile.Type = type;
                }
            }

            return brainStatus;
        }

        public void ShowDisplay()
        {
            Console.Clear();

            var screenLines = Screen.GroupBy(t => t.Y).OrderBy(g => g.Key);

            foreach (var screenLine in screenLines)
            {
                var orderedLine = screenLine.OrderBy(t => t.X);

                foreach (var tile in orderedLine)
                {
                    tile.Print();
                }

                Console.WriteLine();
            }
            
            Console.WriteLine($"Score: {Score}");
        }

        public void PlayGame()
        {
            Brain.FixInputMemory(0, 2);

            var brainStatus = ProgramStatus.WaitingForInput;
            long[] input = null;
            Score = 0;

            while (brainStatus == ProgramStatus.WaitingForInput)
            {
                brainStatus = UpdateDisplay(input);
                //ShowDisplay();

                var paddle = Screen.Find(t => t.Type == TileType.HorizontalPaddle);
                var ball = Screen.Find(t => t.Type == TileType.Ball);
                input = new long[] { -paddle.X.CompareTo(ball.X) };

                //Thread.Sleep(50);

                //var key = Console.ReadKey();

                //if (key.Key == ConsoleKey.Enter)
                //{
                //    input = new long[] { 0 };
                //}
                //else if (key.Key == ConsoleKey.LeftArrow)
                //{
                //    input = new long[] { -1 };
                //}
                //else if (key.Key == ConsoleKey.RightArrow)
                //{
                //    input = new long[] { 1 };
                //}
                //else
                //{
                //    input = null;
                //}
            }
        }
    }
}
