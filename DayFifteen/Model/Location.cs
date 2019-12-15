using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DayFifteen.Model
{
    public class Location : IEquatable<Location>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public LocationType Type { get; set; }
        public int StepsToOrigin { get; set; }

        public Location(int x, int y, LocationType type, int stepToOrigin = int.MaxValue)
        {
            X = x;
            Y = y;
            Type = type;
            StepsToOrigin = stepToOrigin;
        }

        public bool Equals([AllowNull] Location other)
        {
            return GetHashCode() == other.GetHashCode();
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

        public override string ToString()
        {
            return $"({X},{Y}) Type: {Type} From Origin: {StepsToOrigin}";
        }
    }
}
