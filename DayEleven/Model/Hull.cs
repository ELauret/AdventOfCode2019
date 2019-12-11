using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayEleven.Model
{
    public class Hull
    {
        public List<HullPanel> Panels { get; set; }

        public Hull()
        {
            Panels = new List<HullPanel>();
        }

        public HullPanel AddPanel(int x, int y)
        {
            if (Panels.Any(p => p.X == x && p.Y == y)) return null;

            var panel = new HullPanel(x, y);
            Panels.Add(panel);

            return panel;
        }

        public HullPanel GetPanel(int x, int y)
        {
            return Panels.FirstOrDefault(p => p.X == x && p.Y == y) ?? null;
        }
    }
}
