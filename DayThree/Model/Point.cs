using System;
using System.Collections.Generic;

namespace DayThree.Model
{
    public class Point : IComparer<Point>, IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int StepsToReachPoint { get; set; }

        public Point()
        {
            StepsToReachPoint = 0;
        }

        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public Point(Point other) : this(other.X, other.Y) { }

        public int ManhattanDistanceTo(Point point)
        {
            if (point == null) throw new ArgumentNullException(nameof(point));

            return ManhattanDistanceTo(point.X, point.Y);
        }

        public int ManhattanDistanceTo(int x, int y)
        {
            return Math.Abs(X - x) + Math.Abs(Y - y);
        }

        public int Compare(Point p1, Point p2)
        {
            if (p1 == null || p2 == null) throw new ArgumentNullException($"Neither {nameof(p1)} nor {nameof(p2)} can be null.");

            var origin = new Point(0, 0);
            var distance1 = p1.ManhattanDistanceTo(origin);
            var distance2 = p2.ManhattanDistanceTo(origin);

            if (distance1 > distance2) return 1;
            else if (distance1 < distance2) return -1;
            else return 0;
        }

        public int CompareTo(Point other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Compare(this, other);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Point;

            if (other == null) return false;

            if (X == other.X && Y == other.Y) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = 13; //(int) 2166136261
                const int HashingMultiplier = 7; //16777619

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ X.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Y.GetHashCode();

                return hash;
            }
        }

        public static bool operator ==(Point left, Point right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public static bool operator <(Point left, Point right)
        {
            return left is null ? right is object : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Point left, Point right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Point left, Point right)
        {
            return left is object && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Point left, Point right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }
}
