using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace ImageRepositoryClassLibrary
{
    public class ColorCalculation
    {
        /// <summary>
        /// finds the most frequent color on the picture
        /// </summary>
        /// <param name="bmp">bitmap to examine</param>
        /// <returns>RGB color in a string form</returns>
        public static string GetDominantColor(Bitmap bmp)
        {
            Dictionary<string, int> colors = new Dictionary<string, int>();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);
                    string key = $"{color.R} {color.G} {color.B}";

                    if (key != "0 0 0" && key != "255 255 255")
                    {
                        if (colors.Keys.Contains(key)) colors[key]++;
                        else colors.Add(key, 1);
                    }
                }
            }

            string r = colors.OrderByDescending(c => c.Value).First().Key;
            return r;
        }

        /// <summary>
        /// converts RGB string separated by spaces into color
        /// </summary>
        /// <param name="colorText">string to examine</param>
        /// <returns>color converted from the string</returns>
        public static Color ConvertTextToColor(string colorText)
        {
            string[] rgb = colorText.Split(' ');
            return Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
        }

        /// <summary>
        /// converts RGB color into hex string
        /// </summary>
        /// <param name="rgb">RGB color to convert</param>
        /// <returns>deduced hex string</returns>
        public static string ConvertRGBToHex(Color rgb)
        {
            return $"#{rgb.R.ToString("X2")}{rgb.G.ToString("X2")}{rgb.B.ToString("X2")}";
        }

        /// <summary>
        /// finds the closest match in RGB space
        /// Source Code: https://stackoverflow.com/questions/27374550/how-to-compare-color-object-and-get-closest-color-in-an-color
        /// </summary>
        /// <param name="colors">colors to compare with</param>
        /// <param name="target">color target</param>
        /// <returns>idx of the closest color</returns>
        public static int GetClosestColor(List<Color> colors, Color target)
        {
            var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
            return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
        }

        /// <summary>
        /// finds distance in RGB space between two colors
        /// Source Code: https://stackoverflow.com/questions/27374550/how-to-compare-color-object-and-get-closest-color-in-an-color
        /// </summary>
        /// <param name="c1">first color</param>
        /// <param name="c2">second color</param>
        /// <returns></returns>
        public static int ColorDiff(Color c1, Color c2)
        {
            return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                                   + (c1.G - c2.G) * (c1.G - c2.G)
                                   + (c1.B - c2.B) * (c1.B - c2.B));
        }
    }
}
