using FourLeggedHead.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DayFifteen.Model
{
    public class RepairDroid
    {
        public IntcodeComputer Brain { get; set; }

        public RepairDroid(string program)
        {
            Brain = new IntcodeComputer(program);
        }

        public void DiscoverNextFrom(Area area, Location currentLocation, DroidDirection? nextDirection)
        {
            if (area.Locations.Count == 0)
            {
                if(currentLocation == null) currentLocation = new Location(0, 0, LocationType.Empty, 0);
                area.Locations.Add(currentLocation.GetHashCode(), currentLocation);

                foreach (var direction in NextDirections(null))
                {
                    DiscoverNextFrom(area, currentLocation, direction);
                }
            }

            if (nextDirection == null) return;

            _ = Brain.RunProgram((int)nextDirection);
            var locationType = (LocationType)Enum.ToObject(typeof(LocationType), Brain.Output.Dequeue());
            var nextLocation = NextLocation(currentLocation, (DroidDirection)nextDirection, locationType);
            var locationKey = nextLocation.GetHashCode();

            if (area.Locations.ContainsKey(locationKey) &&
                area.Locations[locationKey].StepsToOrigin < currentLocation.StepsToOrigin + 1)
            {
                return;
            }

            if (!area.Locations.ContainsKey(locationKey))
            {
                area.Locations.Add(locationKey, nextLocation);
            }

            if (nextLocation.Type == LocationType.Wall) return;

            if (area.Locations[locationKey].StepsToOrigin > currentLocation.StepsToOrigin + 1)
            {
                nextLocation.StepsToOrigin = currentLocation.StepsToOrigin + 1;
                area.Locations[locationKey] = nextLocation;
            }

            foreach (var direction in NextDirections(nextDirection))
            {
                DiscoverNextFrom(area, nextLocation, direction);
            }
        }

        private List<DroidDirection> NextDirections(DroidDirection? comingDirection)
        {
            var nextDirections = new List<DroidDirection>()
            {
                DroidDirection.North,
                DroidDirection.South,
                DroidDirection.West,
                DroidDirection.East
            };

            if (comingDirection != null) nextDirections.Remove((DroidDirection)comingDirection);

            return nextDirections;
        }

        private Location NextLocation(Location currentLocation, DroidDirection nextDirection, LocationType locationType)
        {
            var x = currentLocation.X;
            var y = currentLocation.Y;

            switch (nextDirection)
            {
                case DroidDirection.North:
                    y--;
                    break;
                case DroidDirection.South:
                    y++;
                    break;
                case DroidDirection.West:
                    x--;
                    break;
                case DroidDirection.East:
                    x++;
                    break;
                default:
                    break;
            }

            return new Location(x, y, locationType);
        }
    }
}
