using System;
using System.Text.RegularExpressions;

namespace DayTwelve.Model
{
    public class JupiterMoon
    {
        private static string _readPattern = @"<x=(?<X>-*\d+), y=(?<Y>-*\d+), z=(?<Z>-*\d+)>";

        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public int PotentialEnergy { get { return Position.Energy; } }
        public int KineticEnergy { get { return Velocity.Energy; } }
        public int TotalEnergy { get { return PotentialEnergy * KineticEnergy; } }

        public JupiterMoon(string moon)
        {
            if (!Regex.IsMatch(moon, _readPattern)) throw new ArgumentException($"{moon} does not match the expected pattern");

            var match = Regex.Match(moon, _readPattern);

            Position = new Vector
            {
                X = int.Parse(match.Groups["X"].Value),
                Y = int.Parse(match.Groups["Y"].Value),
                Z = int.Parse(match.Groups["Z"].Value)
            };

            Velocity = new Vector();
        }

        public JupiterMoon(int[] position, int[] velocity)
        {
            Position = new Vector(position);
            Velocity = new Vector(velocity);
        }

        public override string ToString()
        {
            return $"<x={Position.X}, y={Position.Y}, z={Position.Z}>";
        }

        public void UpdatePosition()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }
    }
}
