using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayFifteen.Model
{
    public class Area
    {
        public Dictionary<int, Location> Locations { get; set; }

        public Area()
        {
            Locations = new Dictionary<int, Location>();
        }

        public void Print()
        {
            var minX = Locations.Values.Min(l => l.X);
        }
    }
}
