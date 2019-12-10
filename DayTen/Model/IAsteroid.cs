using System;
using System.Collections.Generic;
using System.Text;

namespace DayTen.Model
{
    public interface IAsteroid
    {
        int X { get; set; }
        int Y { get; set; }

        string ToString();
        bool Equals(object obj);
        bool BelongsTo(Map map);
        int CountAsteriodsWithDirectLineOfSight(Map map);
    }
}
