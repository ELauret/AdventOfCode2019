using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DayEighteen.Model
{
    public class Map
    {
        public int Width => Locations.Keys.Max(k => k.X) + 1;
        public int Height => Locations.Keys.Max(k => k.Y) + 1;
        public Dictionary<(int X, int Y),Location> Locations { get; set; }


        public Map(IEnumerable<string> map)
        {
            Locations = new Dictionary<(int X, int Y), Location>();

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
                    Locations.Add((x, y), location);
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
            var entrance = Locations.Values.First(l => l.Type == LocationType.Entrance);

            Locations[(entrance.X - 1, entrance.Y)].Type = LocationType.Wall;
            Locations[(entrance.X + 1, entrance.Y)].Type = LocationType.Wall;
        }

        public void BuildTree(Location root)
        {
            root.FindSuccessors(this);

            while (root.Successors.Count == 1)
            {
                root = root.Successors.First();
                root.FindSuccessors(this);
            }

            if (root.Successors.Count > 1)
            {
                foreach (var successor in root.Successors)
                {
                    BuildTree(successor);
                }
            }
        }
    }
}
