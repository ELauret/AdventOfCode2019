using System;
using System.Collections.Generic;
using System.Text;

namespace DayTen.Model
{
    public class EmptyLocation : Location
    {
        public EmptyLocation() { }

        public EmptyLocation(int x, int y) : base(x, y) { }

        public override string ToString()
        {
            return base.ToString() + $"\tThis is an empty location.";
        }
    }
}
