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
        public List<Asteroid> Asteroids { get; }

        public Map(string[] mapFile)
        {
            if (mapFile == null) throw new ArgumentNullException(nameof(mapFile));
            if (mapFile.Length == 0) throw new ArgumentException($"{mapFile} contains no data.");

            Height = mapFile.Length;
            Width = mapFile[0].Length;

            Asteroids = new List<Asteroid>();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (mapFile[i][j].Equals('#')) Asteroids.Add(new Asteroid(j, i));
                }
            }
        }

        public int MaxCountOfDetectableAteroids()
        {
            var counts = new List<int>();
            foreach (var asteroid in Asteroids)
            {
                counts.Add(asteroid.CountAsteriodsWithDirectLineOfSight(Asteroids));
            }

            return counts.Max();
        }
    }
}
