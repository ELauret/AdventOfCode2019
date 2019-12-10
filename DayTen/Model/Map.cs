using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayTen.Model
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<IAsteroid> Asteroids { get; }

        public Map(string[] mapFile)
        {
            if (mapFile == null) throw new ArgumentNullException(nameof(mapFile));
            if (mapFile.Length == 0) throw new ArgumentException($"{mapFile} contains no data.");

            Height = mapFile.Length;
            Width = mapFile[0].Length;

            Asteroids = new List<IAsteroid>();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (mapFile[i][j].Equals('#')) Asteroids.Add(new Asteroid(j, i));
                    else Asteroids.Add(new NullAsteroid(j, i));
                }
            }
        }

        public int MaxCountOfDetectableAteroids(out IAsteroid bestAsteroid)
        {
            bestAsteroid = new Asteroid();

            var maxCount = 0;
            foreach (var asteroid in Asteroids)
            {
                var count = asteroid.CountAsteriodsWithDirectLineOfSight(this);
                if (count > maxCount)
                {
                    maxCount = count;
                    bestAsteroid = asteroid;
                }
            }

            return maxCount;
        }
    }
}
