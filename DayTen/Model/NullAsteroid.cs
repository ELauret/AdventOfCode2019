using System;
using System.Collections.Generic;
using System.Text;

namespace DayTen.Model
{
    public class NullAsteroid : IAsteroid
    {
        public int X { get; set; }
        public int Y { get; set; }

        public NullAsteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool BelongsTo(Map map)
        {
            if (map == null) return false;

            return map.Asteroids.Contains(this);
        }

        public int CountAsteriodsWithDirectLineOfSight(Map map)
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            var asteroid = obj as IAsteroid;

            if (asteroid == null) return false;

            return (X == asteroid.X) && (Y == asteroid.Y); ;
        }

        public override string ToString()
        {
            return $"A({ X},{ Y}) This is a Null asteroid.";
        }
    }
}
