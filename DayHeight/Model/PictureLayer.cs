using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public PictureLayer(int width, int height)
        {
            Width = width;
            Height = height;
            Rows = new LayerRow[Height];
            for (int i = 0; i < Height; i++)
            {
                Rows[i] = new LayerRow(Width);
            }
        }

        public int CountOfZeroDigits()
        {
            return Rows.Sum(r => r.CountOfZeroDigits());
        }

        public int LayerCheck()
        {
            var flatenedLayer = Rows.SelectMany(r => r.PixelColors);

            return flatenedLayer.Count(c => c == 1) * flatenedLayer.Count(c => c == 2);
        }

        public void Print()
        {
            foreach (var row in Rows)
            {
                Console.WriteLine(string.Join("", row.PixelColors).Replace('0', ' '));
            }
        }
    }
}
