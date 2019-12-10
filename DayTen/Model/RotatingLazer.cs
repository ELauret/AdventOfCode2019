using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayTen.Model
{
    public class RotatingLazer
    {
        public Asteroid Location { get; set; }

        public RotatingLazer(Asteroid asteroid)
        {
            if (asteroid == null) throw new ArgumentNullException(nameof(asteroid));
            Location = asteroid;
        }

        //public Asteroid VaporizeAsteroids(Map map, int count)
        //{
        //    var x = Location.X;
        //    var y = 0;

        //    while (count > 0)
        //    {
        //        var xRange = Asteroid.GetRangeX(Location, new NullAsteroid(x, y));
        //        var yRange = Asteroid.GetRangeY(Location, new NullAsteroid(x, y));

        //        map.NextBorderCoordinates(ref x, ref y);
        //    }
        //}
    }
}
