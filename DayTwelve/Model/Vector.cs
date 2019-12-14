using System;

namespace DayTwelve.Model
{
#pragma warning disable CS0659 // 'Vector' overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Vector
#pragma warning restore CS0659 // 'Vector' overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Energy { get { return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z); } }

        public Vector() { }

        public Vector(int[] vector)
        {
            if (vector == null) throw new ArgumentNullException(nameof(vector));
            if (vector.Length != 3) throw new ArgumentException("Int array supplied is of the wrong size");

            X = vector[0];
            Y = vector[1];
            Z = vector[2];
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Vector))
                throw new ArgumentException($"Object supplied is of the wrong type. {typeof(Vector)} expected");

            var vector = obj as Vector;

            return (X == vector.X) && (Y == vector.Y) && (Z == vector.Z);
        }
    }
}
