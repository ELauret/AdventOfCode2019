using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using FourLeggedHead.Tools;

namespace DayEighteen.Model
{
    public class Location : IVertex, IEquatable<Location>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public LocationType Type { get; set; }
        public char? Artefact { get; set; }
        public IVertex Parent { get; set; }

        public Location(int x, int y, LocationType type, char? artefact = null)
        {
            X = x;
            Y = y;
            Type = type;
            Artefact = artefact;
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
    }
}
