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
        public List<ILocation> Locations { get; }

        public Map(string[] mapFile)
        {
            if (mapFile == null) throw new ArgumentNullException(nameof(mapFile));
            if (mapFile.Length == 0) throw new ArgumentException($"{mapFile} contains no data.");

            Height = mapFile.Length;
            Width = mapFile[0].Length;

            Locations = new List<ILocation>();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (mapFile[i][j].Equals('#')) Locations.Add(new Asteroid(j, i));
                    else Locations.Add(new EmptyLocation(j, i));
                }
            }
        }

        public int MaxCountOfDetectableAteroids(out Asteroid bestAsteroid)
        {
            bestAsteroid = new Asteroid();

            var maxCount = 0;
            foreach (var location in Locations)
            {
                if (location.GetType() != typeof(Asteroid)) continue;

                var count = ((Asteroid)location).CountAsteroidsWithDirectLineOfSight(this);
                if (count > maxCount)
                {
                    maxCount = count;
                    bestAsteroid = (Asteroid)location;
                }
            }

            return maxCount;
        }

        public void NextBorderCoordinates(ref int i, ref int j)
        {
            if (i == 0 && j > 0) j--;
            else if (i == Width - 1 && j < Height - 1) j++;
            else if (j == 0 && i < Width - 1) i++;
            else if (i > 0) i--;
        }
    }
}
