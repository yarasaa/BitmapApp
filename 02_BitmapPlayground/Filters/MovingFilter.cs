using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BitmapPlayground.Filters
{
    public class MovingFilter : IFilter
    {
        public Color[,] Apply(Color[,] input)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            Color[,] result = new Color[width, height];

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    var p = input[x, y];
                    var pl = input[(x - 1), y];
                    var pr = input[x, (y - 1)];
                    var pa = input[(x + 1), y];
                    var pb = input[x, (y + 1)];
                    int avgr = (pl.R + pr.R + pa.R + pb.R) / 4;
                    int avgg = (pl.G + pr.G + pa.G + pb.G) / 4;
                    int avgb = (pl.B + pr.B + pa.B + pb.B) / 4;
                    result[x, y] = Color.FromArgb(p.A, avgr, avgg, avgb);
                }
            }

            return result;
        }

        public string Name => "Moving Average Filter";

        public override string ToString()
            => Name;

    }
}

