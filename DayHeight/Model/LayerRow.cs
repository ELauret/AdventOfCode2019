using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreLinq;

namespace DayHeight.Model
{
    public class LayerRow
    {
        public int Width { get; set; }
        public int[] PixelColors { get; set; }

        public LayerRow(IEnumerable<char> encodedRow)
        {
            Width = encodedRow.Count();
            PixelColors = new int[Width];
            for (int i = 0; i < Width; i++)
            {
                PixelColors[i] = int.Parse(encodedRow.ElementAt(i).ToString());
            }
        }

        public int CountOfZeroDigits()
        {
            return PixelColors.Count(c => c == 0);
        }
    }
}
