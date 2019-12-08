using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreLinq;

namespace DayHeight.Model
{
    public class PictureLayer
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public LayerRow[] Rows { get; set; }

        public PictureLayer(int height, IEnumerable<char> encodedLayer)
        {
            Height = height;
            Width = encodedLayer.Count() / Height;

            Rows = new LayerRow[Height];
            var rows = encodedLayer.Batch(Width);
            for (int i = 0; i < Height; i++)
            {
                Rows[i] = new LayerRow(rows.ElementAt(i));
            }
        }

        public int CountOfZeroDigits()
        {
            return Rows.Sum(r => r.CountOfZeroDigits());
        }
    }
}
