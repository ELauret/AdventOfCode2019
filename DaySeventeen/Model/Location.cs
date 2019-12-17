using System;
using System.Collections.Generic;
using System.Text;

namespace DaySeventeen.Model
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public LocationType Type { get; set; }

        public Location(int x, int y, LocationType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public override string ToString()
        {
            return $"({X,3},{Y,3}) Type: {Type}";
        }
    }
}
