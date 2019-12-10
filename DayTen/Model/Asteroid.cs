using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DayTen.Model
{
    public class Asteroid
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool HasDirectLineOfSight(List<Asteroid> map, Asteroid targetAsteroid)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            if (targetAsteroid == null) throw new ArgumentNullException(nameof(targetAsteroid));

            if (!BelongsTo(map) || !targetAsteroid.BelongsTo(map)) throw new ArgumentException("One or both asteroids do not belong to the map.");

            var rangeX = GetRangeX(this, targetAsteroid);
            var rangeY = GetRangeY(this, targetAsteroid);

            for (int i = rangeX.Min; i < rangeX.Max + 1; i++)
            {
                for (int j = rangeY.Min; j < rangeY.Max + 1; j++)
                {
                    var asteroid = map.Find(a => a.X == i && a.Y == j);

                    if (asteroid != null && !asteroid.Equals(this) && !asteroid.Equals(targetAsteroid)
                        && asteroid.IsAlignedWith(this, targetAsteroid)) return false;
                }
            }

            return true;
        }

        public int CountAsteriodsWithDirectLineOfSight(List<Asteroid> map)
        {
            var count = 0;

            foreach (var asteroid in map)
            {
                if (!asteroid.Equals(this) && HasDirectLineOfSight(map, asteroid)) count++;
            }

            return count;
        }

        public override bool Equals(object obj)
        {
            var asteroid = obj as Asteroid;

            if (asteroid == null) return false;

            return (X == asteroid.X) && (Y == asteroid.Y); ;
        }

        public bool BelongsTo(List<Asteroid> map)
        {
            if (map == null) return false;

            return map.Contains(this);
        }

        public bool IsAlignedWith(Asteroid firstAsteroid, Asteroid secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            var determinant = X * (firstAsteroid.Y - secondAsteroid.Y)
                + firstAsteroid.X * (secondAsteroid.Y - Y) + secondAsteroid.X * (Y - firstAsteroid.Y);
            
            if (determinant == 0) return true;

            return false;
        }

        public static (int Min, int Max) GetRangeX(Asteroid firstAsteroid, Asteroid secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            if (firstAsteroid.X < secondAsteroid.X) return (firstAsteroid.X, secondAsteroid.X);
            else return (secondAsteroid.X, firstAsteroid.X);
        }

        public static (int Min, int Max) GetRangeY(Asteroid firstAsteroid, Asteroid secondAsteroid)
        {
            if (firstAsteroid == null || secondAsteroid == null) throw new ArgumentNullException();

            if (firstAsteroid.Y < secondAsteroid.Y) return (firstAsteroid.Y, secondAsteroid.Y);
            else return (secondAsteroid.Y, firstAsteroid.Y);
        }

        public override string ToString()
        {
            return $"A({X},{Y})";
        }
    }
}