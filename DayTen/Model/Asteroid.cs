using System;
using System.Numerics;

namespace DayTen.Model
{
    public class Asteroid : Location
    {
        public double Radius { get; set; }
        public double Angle { get; set; }

        public Asteroid() { }

        public Asteroid(int x, int y) : base(x, y) { }

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
                    var asteroid = map.Locations[j * map.Width + i];

                    if (asteroid.GetType() != typeof(EmptyLocation) && asteroid != null && !asteroid.Equals(this)
                        && !asteroid.Equals(targetAsteroid) && ((Asteroid)asteroid).IsAlignedWith(this, targetAsteroid)) return false;
                }
            }

            return true;
        }

        public int CountAsteroidsWithDirectLineOfSight(Map map)
        {
            var count = 0;

            foreach (var asteroid in map.Locations)
            {
                if (asteroid.GetType() != typeof(EmptyLocation) && !asteroid.Equals(this)
                    && HasDirectLineOfSight(map, (Asteroid)asteroid)) count++;
            }

            return count;
        }

        public bool IsAlignedWith(ILocation firstAsteroid, ILocation secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            var determinant = X * (firstAsteroid.Y - secondAsteroid.Y)
                + firstAsteroid.X * (secondAsteroid.Y - Y) + secondAsteroid.X * (Y - firstAsteroid.Y);

            if (determinant == 0) return true;

            return false;
        }

        public static (int Min, int Max) GetRangeX(ILocation firstAsteroid, ILocation secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            if (firstAsteroid.X < secondAsteroid.X) return (firstAsteroid.X, secondAsteroid.X);
            else return (secondAsteroid.X, firstAsteroid.X);
        }

        public static (int Min, int Max) GetRangeY(ILocation firstAsteroid, ILocation secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            if (firstAsteroid.Y < secondAsteroid.Y) return (firstAsteroid.Y, secondAsteroid.Y);
            else return (secondAsteroid.Y, firstAsteroid.Y);
        }

        public void GetPolarCoordinatesFrom(ILocation asteroid)
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

        public override string ToString()
        {
            if (Radius > 0.0) return base.ToString() + $"\tAp({Radius:F3},{Angle * 180 / Math.PI:F3})";
            else return base.ToString();
        }
    }
}