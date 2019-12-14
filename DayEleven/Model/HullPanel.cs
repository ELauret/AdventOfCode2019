using System;

namespace DayEleven.Model
{
#pragma warning disable CS0659 // 'HullPanel' overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class HullPanel
#pragma warning restore CS0659 // 'HullPanel' overrides Object.Equals(object o) but does not override Object.GetHashCode()
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

        public override string ToString()
        {
            return $"Panel: ({X},{Y})";
        }
    }
}
