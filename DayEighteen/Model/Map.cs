using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FourLeggedHead.Tools;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DayEighteen.Model
{
    public class Map : List<Location>, IGraph<int>
    {
        public int Width => ((IEnumerable<Location>)this).Max(k => k.X) + 1;
        public int Height => ((IEnumerable<Location>)this).Max(k => k.Y) + 1;


        public Map(IEnumerable<string> map)
        {
            var x = 0;
            var y = 0;

            foreach (var row in map)
            {
                var features = row.ToCharArray();
                foreach (var feature in features)
                {
                    var type = DetermineType(feature);
                    var location = new Location(x, y, type,
                        type == LocationType.Door || type == LocationType.Key ? (char?)feature : null);
                    Add(location);
                    x++;
                }
                x = 0;
                y++;
            }
        }

        private LocationType DetermineType(char type)
        {
            return type switch
            {
                '#' => LocationType.Wall,
                char t when (t >= 65 && t <= 90) => LocationType.Door,
                char t when (t >= 97 && t <= 122) => LocationType.Key,
                '@' => LocationType.Entrance,
                _ => LocationType.Empty,
            };
        }

        public void FixMapNearEntrance()
        {
            var entrance = Find(l => l.Type == LocationType.Entrance);

            Find(l => l.X == entrance.X - 1 && l.Y == entrance.Y).Type = LocationType.Wall;
            Find(l => l.X == entrance.X + 1 && l.Y == entrance.Y).Type = LocationType.Wall;
        }

        public int? DistanceBetweenNeighbors(IVertex firstVertex, IVertex secondVertex)
        {
            if (!GetNeighbors(firstVertex).Contains(secondVertex)) return null;

            return 1;
        }

        public int DistanceBetweenVertices(IVertex firstVertex, IVertex secondVertex)
        {
            if (firstVertex == secondVertex) return 0;

            throw new NotImplementedException();
        }

        public int MaxDistance()
        {
            return int.MaxValue;
        }

        public int AddDistance(int firstDistance, int secondDistance)
        {
            return firstDistance + secondDistance;
        }

        public IEnumerable<IVertex> GetNeighbors(IVertex vertex)
        {
            var currentLocation = vertex as Location;

            if (!Contains(currentLocation)) throw new ArgumentException("The vertex does not belong to the map.");
            if (currentLocation == null || currentLocation.Type == LocationType.Wall) return null;

            var neighbors = new List<Location>();

            var above = Find(l => l.X == currentLocation.X && l.Y == currentLocation.Y - 1);
            if (above != null && above.Type != LocationType.Wall) neighbors.Add(above);

            var below = Find(l => l.X == currentLocation.X && l.Y == currentLocation.Y + 1);
            if (below != null && below.Type != LocationType.Wall) neighbors.Add(below);

            var left = Find(l => l.X == currentLocation.X - 1 && l.Y == currentLocation.Y);
            if (left != null && left.Type != LocationType.Wall) neighbors.Add(left);

            var right = Find(l => l.X == currentLocation.X + 1 && l.Y == currentLocation.Y);
            if (right != null && right.Type != LocationType.Wall) neighbors.Add(right);

            return neighbors;
        }

        IEnumerator<IVertex> IEnumerable<IVertex>.GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
