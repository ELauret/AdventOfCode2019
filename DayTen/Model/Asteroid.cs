using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace DayTen.Model
{
    public class Asteroid : IAsteroid
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Radius { get; set; }
        public double Angle { get; set; }

        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Asteroid() { }

        public bool HasDirectLineOfSight(Map map, Asteroid targetAsteroid)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            if (targetAsteroid == null) throw new ArgumentNullException(nameof(targetAsteroid));

            if (!BelongsTo(map) || !targetAsteroid.BelongsTo(map))
                throw new ArgumentException("One or both asteroids do not belong to the map.");

            var rangeX = GetRangeX(this, targetAsteroid);
            var rangeY = GetRangeY(this, targetAsteroid);

            for (int i = rangeX.Min; i < rangeX.Max + 1; i++)
            {
                for (int j = rangeY.Min; j < rangeY.Max + 1; j++)
                {
                    var asteroid = map.Asteroids[j * map.Width + i];

                    if (asteroid.GetType() != typeof(NullAsteroid) && asteroid != null && !asteroid.Equals(this)
                        && !asteroid.Equals(targetAsteroid) && ((Asteroid)asteroid).IsAlignedWith(this, targetAsteroid)) return false;
                }
            }

            return true;
        }

        public int CountAsteriodsWithDirectLineOfSight(Map map)
        {
            var count = 0;

            foreach (var asteroid in map.Asteroids)
            {
                if (asteroid.GetType() != typeof(NullAsteroid) && !asteroid.Equals(this)
                    && HasDirectLineOfSight(map, (Asteroid)asteroid)) count++;
            }

            return count;
        }

        public override bool Equals(object obj)
        {
            var asteroid = obj as IAsteroid;

            if (asteroid == null) return false;

            return (X == asteroid.X) && (Y == asteroid.Y); ;
        }

        public bool BelongsTo(Map map)
        {
            if (map == null) return false;

            return map.Asteroids.Contains(this);
        }

        public bool IsAlignedWith(IAsteroid firstAsteroid, IAsteroid secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            var determinant = X * (firstAsteroid.Y - secondAsteroid.Y)
                + firstAsteroid.X * (secondAsteroid.Y - Y) + secondAsteroid.X * (Y - firstAsteroid.Y);

            if (determinant == 0) return true;

            return false;
        }

        public static (int Min, int Max) GetRangeX(IAsteroid firstAsteroid, IAsteroid secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            if (firstAsteroid.X < secondAsteroid.X) return (firstAsteroid.X, secondAsteroid.X);
            else return (secondAsteroid.X, firstAsteroid.X);
        }

        public static (int Min, int Max) GetRangeY(IAsteroid firstAsteroid, IAsteroid secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            if (firstAsteroid.Y < secondAsteroid.Y) return (firstAsteroid.Y, secondAsteroid.Y);
            else return (secondAsteroid.Y, firstAsteroid.Y);
        }

        public override string ToString()
        {
            if (Radius > 0.0) return $"Ac({X},{Y})\tAp({Radius:F3},{Angle * 180 / Math.PI:F3})";            
            else return $"Ac({X},{Y})";
        }

        public int DistanceTo(IAsteroid asteroid)
        {
            if (asteroid == null) throw new ArgumentNullException(nameof(asteroid));

            return Math.Abs(X - asteroid.X) + Math.Abs(Y - asteroid.Y);
        }

        public void GetPolarCoordinatesFrom(IAsteroid asteroid)
        {
            if (asteroid == null) throw new ArgumentNullException(nameof(asteroid));

            var complex = new Complex(X - asteroid.X, Y - asteroid.Y);

            Radius = complex.Magnitude;
            Angle = ChangeAngleToClockwiseFromNorth(complex.Phase);
        }

        private static double ChangeAngleToClockwiseFromNorth(double angle)
        {
            angle = angle + Math.PI / 2;
            if (angle < 0.0) angle += 2 * Math.PI;

            return angle;
        }
    }
}