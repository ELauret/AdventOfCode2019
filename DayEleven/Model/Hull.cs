using System;
using System.Collections.Generic;
using System.Linq;

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

        public void ViewHull()
        {
            var maxX = Panels.Max(p => p.X) + 1;
            var minX = Panels.Min(p => p.X) - 1;
            var maxY = Panels.Max(p => p.Y) + 1;
            var minY = Panels.Min(p => p.Y) - 1;

            for (int j = minY; j < maxY; j++)
            {
                for (int i = maxX; i > minX; i--)
                {
                    var paintedPanel = GetPanel(i, j);

                    if (paintedPanel == null || paintedPanel.Color == PaintColor.Black) Console.Write(" ");
                    else Console.Write("#");
                }
                Console.WriteLine();
            }
        }
    }
}
