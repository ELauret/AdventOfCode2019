using System;
using System.Collections.Generic;
using System.Text;

namespace DayThirteen.Model
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileType Type { get; set; }

        public Tile(int x, int y, TileType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public void Print()
        {
            switch (Type)
            {
                case TileType.Empty:
                    Console.Write(" ");
                    break;
                case TileType.Wall:
                    Console.Write("|");
                    break;
                case TileType.Block:
                    Console.Write("#");
                    break;
                case TileType.HorizontalPaddle:
                    Console.Write("_");
                    break;
                case TileType.Ball:
                    Console.Write("O");
                    break;
                default:
                    break;
            }
        }
    }
}
