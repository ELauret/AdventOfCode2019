using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace DayTwelve.Model
{
    public class GlobalSystem
    {
        private static string _readPattern = @"<x=(?<X>-*\d+), y=(?<Y>-*\d+), z=(?<Z>-*\d+)>";

        public GlobalMatrix Positions { get; set; }
        public GlobalMatrix Velocities { get; set; }
        public int Size { get; set; }

        public GlobalSystem(string[] moons)
        {
            Size = moons.Length;

            Positions = new GlobalMatrix(Size, moons, _readPattern);
            Velocities = new GlobalMatrix(Size);
        }

        public int UpdateSystem(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                UpdateVelocities();
                Updateposition();
            }

            return TotalEnergy();
        }

        public void UpdateVelocities()
        {
            for (int i = 0; i < Size; i++)
            {
                var xPosition = Positions.X[i];
                Velocities.X[i] += Positions.X.Count(x => x > xPosition) - Positions.X.Count(x => x < xPosition);

                var yPosition = Positions.Y[i];
                Velocities.Y[i] += Positions.Y.Count(y => y > yPosition) - Positions.Y.Count(y => y < yPosition);

                var zPosition = Positions.Z[i];
                Velocities.Z[i] += Positions.Z.Count(z => z > zPosition) - Positions.Z.Count(z => z < zPosition);
            }
        }

        public void Updateposition()
        {
            for (int i = 0; i < Size; i++)
            {
                Positions.X[i] += Velocities.X[i];
                Positions.Y[i] += Velocities.Y[i];
                Positions.Z[i] += Velocities.Z[i];
            }
        }

        public int TotalEnergy()
        {
            var totalEnergy = 0;

            for (int i = 0; i < Size; i++)
            {
                totalEnergy += (Math.Abs(Positions.X[i]) + Math.Abs(Positions.Y[i]) + Math.Abs(Positions.Z[i]))
                    * (Math.Abs(Velocities.X[i]) + Math.Abs(Velocities.Y[i]) + Math.Abs(Velocities.Z[i]));
            }

            return totalEnergy;
        }
    }
}
