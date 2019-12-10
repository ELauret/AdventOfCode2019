using System;
using System.Collections.Generic;
using System.Text;

namespace DayTen.Model
{
    public abstract class Location : ILocation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location() { }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool BelongsTo(Map map)
        {
            if (map == null) return false;

            return map.Locations.Contains(this);
        }

        public int DistanceTo(ILocation location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));

            return Math.Abs(X - location.X) + Math.Abs(Y - location.Y);
        }

        public override bool Equals(object obj)
        {
            var asteroid = obj as ILocation;

            if (asteroid == null) return false;

            return (X == asteroid.X) && (Y == asteroid.Y); ;
        }

        public override string ToString()
        {
            return $"Ac({X},{Y})";
        }
    }
}
