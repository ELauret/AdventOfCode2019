using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MoreLinq;

namespace DayHeight.Model
{
    public class Picture
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<PictureLayer> Layers { get; set; }

        public Picture(int width, int height, string encodedPicture)
        {
            Width = width;
            Height = height;

            Layers = new List<PictureLayer>();
            var layers = encodedPicture.Batch(Height * Width);
            foreach (var layer in layers)
            {
                var pictureLayer = new PictureLayer(Height, layer);
                Layers.Add(pictureLayer);
            }
        }

        public PictureLayer GetLayerWithFewestZeroDigits()
        {
            var layersWithFewestZeroDigits = Layers.MinBy(l => l.CountOfZeroDigits());

            return layersWithFewestZeroDigits.First();
        }
    }
}
