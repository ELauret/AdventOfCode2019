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
                var xPosition = Positions.Coordinates[1][i];
                Velocities.Coordinates[1][i] += Positions.Coordinates[1].Count(x => x > xPosition)
                                                - Positions.Coordinates[1].Count(x => x < xPosition);

                var yPosition = Positions.Coordinates[2][i];
                Velocities.Coordinates[2][i] += Positions.Coordinates[2].Count(y => y > yPosition)
                                                - Positions.Coordinates[2].Count(y => y < yPosition);

                var zPosition = Positions.Coordinates[3][i];
                Velocities.Coordinates[3][i] += Positions.Coordinates[3].Count(z => z > zPosition)
                                                - Positions.Coordinates[3].Count(z => z < zPosition);
            }
        }

        //public int FindFrequencyOfOneDirection(int direction)
        //{
        //    var listPositions = new List<int[]>();
        //    var position = new int[Size];
        //    for (int i = 0; i < Size; i++)
        //    {
        //        position[i] = Positions.Coordinates[direction][i];
        //    }

        //    var frequency = 0;
        //    var _continue = true;

        //    while (_continue)
        //    {
        //        frequency++;

        //        UpdateVelocitiesOfOneDirection(direction);
        //        UpdatepositionOfOneDirection(direction);

        //        positionX = new int[Size];
        //        for (int i = 0; i < Size; i++)
        //        {
        //            positionX[i] = Positions.X[i];
        //        }

        //        if (xPositions.Any(p => ArrayAreEquals(p, positionX))) break;

        //        xPositions.Add(positionX);
        //    }

        //    return frequency;
        //}

        public bool ArrayAreEquals(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length) return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }

            return true;
        }

        public void UpdateVelocitiesOfOneDirection(int direction)
        {
            for (int i = 0; i < Size; i++)
            {
                var xPosition = Positions.Coordinates[direction][i];
                Velocities.Coordinates[direction][i] +=
                    Positions.Coordinates[direction].Count(x => x > xPosition)
                    - Positions.Coordinates[direction].Count(x => x < xPosition);
            }
        }

        public void Updateposition()
        {
            for (int i = 0; i < Size; i++)
            {
                Positions.Coordinates[1][i] += Velocities.Coordinates[1][i];
                Positions.Coordinates[2][i] += Velocities.Coordinates[2][i];
                Positions.Coordinates[3][i] += Velocities.Coordinates[3][i];
            }
        }

        public void UpdatepositionOfOneDirection(int direction)
        {
            for (int i = 0; i < Size; i++)
            {
                Positions.Coordinates[direction][i] += Velocities.Coordinates[direction][i];
            }
        }

        public int TotalEnergy()
        {
            var totalEnergy = 0;

            for (int i = 0; i < Size; i++)
            {
                totalEnergy += (Math.Abs(Positions.Coordinates[1][i])
                                + Math.Abs(Positions.Coordinates[2][i])
                                + Math.Abs(Positions.Coordinates[3][i]))
                            * (Math.Abs(Velocities.Coordinates[1][i])
                                + Math.Abs(Velocities.Coordinates[2][i])
                                + Math.Abs(Velocities.Coordinates[3][i]));
            }

            return totalEnergy;
        }
    }
}
