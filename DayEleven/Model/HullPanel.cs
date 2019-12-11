using System;
using System.Collections.Generic;
using System.Text;

namespace DayEleven.Model
{
    public class HullPanel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PaintColor Color { get; set; }

        public HullPanel(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var panel = obj as HullPanel ?? throw new ArgumentException(
                $"{nameof(obj)} is null or of the wrong type. Expecing a {typeof(HullPanel)}");

            return (X == panel.X) && (Y == panel.Y);
        }
    }
}
