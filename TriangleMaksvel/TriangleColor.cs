using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TriangleMaksvel
{
    public static class TriangleColor
    {
        private static PointF VertexR, VertexG, VertexB;

        private static double THeight;

        private const double Rad60 = Math.PI / 3;

        private static readonly double Tan60, Sin60;

        private static int Sqwidth;

        static TriangleColor()
        {
            Tan60 = Math.Tan(Rad60);
            Sin60 = Math.Sin(Rad60);
        }

        public static void DrawColorTriangle(PictureBox pictureBox, bool bright)
        {
            Sqwidth = pictureBox.Width;//Размер треугольника

            THeight = (Sqwidth / 2) * Tan60;//Высота треугольника

            pictureBox.Height = (int)Math.Round(THeight);

            var TriangleImage = new Bitmap(pictureBox.Width, pictureBox.Height);

            VertexR = new PointF(Sqwidth / 2, 0);
            VertexG = new PointF(0, (float)THeight);
            VertexB = new PointF(Sqwidth, (float)THeight);

            GraphicsPath TrianglePath = new GraphicsPath();

            TrianglePath.AddPolygon(new PointF[] { VertexR, VertexG, VertexB });
            var TriangleRegion = new Region(TrianglePath);

            Point TestPoint = new Point();


            for (int y = 0; y <= TriangleImage.Height - 1; y++)
            {
                for (int x = 0; x <= TriangleImage.Width - 1; x++)
                {
                    TestPoint.X = x;
                    TestPoint.Y = y;

                    if (TriangleRegion.IsVisible(TestPoint))
                    {

                        if (bright)
                            TriangleImage.SetPixel(x, y, GetBrightGradedColorAtPoint(TestPoint));
                        else
                            TriangleImage.SetPixel(x, y, GetGradedColorAtPoint(TestPoint));
                    }
                }
            }

            //for (int i = 0; i < Sqwidth; i++)
            //{
            //    for (int j = 0; j < TriangleImage.Height; j++)
            //    {
            //        double R = (THeight - j) / THeight;
            //        double B = (Math.Sin(Rad60) * (i - (R * THeight) / Math.Tan(Rad60))) / THeight;
            //        double G = 1 - R - B;


            //        if (R >= 0 && R <= 1d && G >= 0 && G <= 1d && B >= 0 && B <= 1d)
            //        {
            //            Point pt = new Point(i, TriangleImage.Height - 1 - j);
            //            TriangleImage.SetPixel(pt.X, pt.Y, Color.FromArgb((int)Math.Round(R * 255), (int)Math.Round(G * 255), (int)Math.Round(B * 255)));
            //        }
            //    }
            //}

            pictureBox.Image = TriangleImage;
        }

        public static Color GetGradedColorAtPoint(Point point)
        {

            double R = (THeight - point.Y) / THeight;
            double B = (Sin60 * (point.X - (R * THeight) / Tan60)) / THeight;
            double G = Math.Abs(1 - R - B);

            return Color.FromArgb((int)Math.Round(R * 255), (int)Math.Round(G * 255), (int)Math.Round(B * 255));
        }

        public static Color GetBrightGradedColorAtPoint(Point point)
        {
            double R = (THeight - point.Y) / THeight;
            double B = (Sin60 * (point.X - (R * THeight) / Tan60)) / THeight;
            double G = Math.Abs(1 - R - B);

            double maxRGB = 1 / Math.Max(Math.Max(R, B), G);
            double NewR = maxRGB * R;
            double NewB = maxRGB * B;
            double NewG = maxRGB * G;

            return Color.FromArgb((int)Math.Round(NewR * 255), (int)Math.Round(NewG * 255), (int)Math.Round(NewB * 255));
        }
    }
}
