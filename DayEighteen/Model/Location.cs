using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DayEighteen.Model
{
    public class Location : IEquatable<Location>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public LocationType Type { get; set; }
        public char? Artefact { get; set; }
        public Location Predecessor { get; set; }
        public List<Location> Successors { get; set; }


        public Location(int x, int y, LocationType type, char? artefact = null)
        {
            X = x;
            Y = y;
            Type = type;
            Artefact = artefact;
            Successors = new List<Location>();
        }

        public bool Equals([AllowNull] Location other)
        {
            if (X == other.X && Y == other.Y && Type != other.Type)
                throw new ArgumentException($"The location at ({X},{Y}) has two different types: {Type} and {other.Type}");

            return X == other?.X && Y == other?.Y;
        }

        public override string ToString()
        {
            return $"({Type}: {X}, {Y}) {Artefact}";
        }

        public void FindSuccessors(Map map)
        {
            if (Type == LocationType.Wall) return;

            var above = (X, Y - 1);
            if (map.Locations[above].Type != LocationType.Wall)
            {
                Successors.Add(map.Locations[above]);
                map.Locations[above].Predecessor = this;
            }

            var below = (X, Y + 1);
            if (map.Locations[below].Type != LocationType.Wall)
            {
                Successors.Add(map.Locations[below]);
                map.Locations[below].Predecessor = this;
            }

            var left = (X - 1, Y);
            if (map.Locations[left].Type != LocationType.Wall)
            {
                Successors.Add(map.Locations[left]);
                map.Locations[left].Predecessor = this;
            }

            var right = (X + 1, Y);
            if (map.Locations[right].Type != LocationType.Wall)
            {
                Successors.Add(map.Locations[right]);
                map.Locations[right].Predecessor = this;
            }
        }
    }
}
