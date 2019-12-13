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
                UpdatePosition();
            }

            return TotalEnergy();
        }

        public void UpdateVelocities()
        {
            UpdateVelocitiesOfOneDirection(0);
            UpdateVelocitiesOfOneDirection(1);
            UpdateVelocitiesOfOneDirection(2);
        }

        public void UpdatePosition()
        {
            UpdatePositionOfOneDirection(0);
            UpdatePositionOfOneDirection(1);
            UpdatePositionOfOneDirection(2);
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

        public void UpdatePositionOfOneDirection(int direction)
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
                totalEnergy += (Math.Abs(Positions.Coordinates[0][i])
                                + Math.Abs(Positions.Coordinates[1][i])
                                + Math.Abs(Positions.Coordinates[2][i]))
                            * (Math.Abs(Velocities.Coordinates[0][i])
                                + Math.Abs(Velocities.Coordinates[1][i])
                                + Math.Abs(Velocities.Coordinates[2][i]));
            }

            return totalEnergy;
        }

        public long FindFrequencyOfOneDirection(int direction)
        {
            var systemStates = new Dictionary<ulong, long>();

            long step = 0;

            while (true)
            {
                var state = GetSystemState(direction);

                if (systemStates.ContainsKey(state))
                {
                    return step - systemStates[state];
                }

                systemStates.Add(state, step);

                UpdateVelocitiesOfOneDirection(direction);
                UpdatePositionOfOneDirection(direction);

                step++;
            }
        }

        public ulong GetSystemState(int direction)
        {
            var myHash = Velocities.GetHash(direction) | (Positions.GetHash(direction) << Velocities.Size * 8);

            var otherHash = ((ulong)(Positions.Coordinates[direction][0] & 0xff)) |
                    ((ulong)(Velocities.Coordinates[direction][0] & 0xff) << 8) |
                    ((ulong)(Positions.Coordinates[direction][1] & 0xff) << 16) |
                    ((ulong)(Velocities.Coordinates[direction][1] & 0xff) << 24) |
                    ((ulong)(Positions.Coordinates[direction][2] & 0xff) << 32) |
                    ((ulong)(Velocities.Coordinates[direction][2] & 0xff) << 40) |
                    ((ulong)(Positions.Coordinates[direction][3] & 0xff) << 48) |
                    ((ulong)(Velocities.Coordinates[direction][3] & 0xff) << 56);

            return otherHash;
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            while (a != b)
            {
                if (a % b == 0) return b;
                if (b % a == 0) return a;
                if (a > b) a -= b;
                if (b > a) b -= a;
            }
            return a;
        }

        public static long LeastCommonMultiplier(long a, long b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }
    }
}
