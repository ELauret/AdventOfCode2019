using System;

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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is ILocation)) return false;

            var location = obj as ILocation;

            return (GetType() == obj.GetType()) && (X == location.X) && (Y == location.Y); ;
        }

        public override string ToString()
        {
            return $"Ac({X},{Y})";
        }
    }
}
