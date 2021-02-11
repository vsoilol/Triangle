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

        public static void DrawColorTriangle(PictureBox pictureBox)
        {
            int Sqwidth = 255;//Размер треугольника

            THeight = Math.Abs((Sqwidth / 2) * Math.Tan(Rad60));//Высота треугольника

            pictureBox.Height = (int)Math.Round(THeight);
            pictureBox.Width = Sqwidth;

            var TriangleImage = new Bitmap(pictureBox.Width, pictureBox.Height);

            VertexR = new PointF(Sqwidth / 2, 0);
            VertexG = new PointF(0, (float)THeight);
            VertexB = new PointF(Sqwidth, (float)THeight);


            GraphicsPath TrianglePath = new GraphicsPath();

            TrianglePath.AddPolygon(new PointF[] { VertexR, VertexG, VertexB });

            Point TestPoint = new Point();

            Random random = new Random();

            for (int y = 0; y <= TriangleImage.Height - 1; y++)
            {

                for (int x = 0; x <= TriangleImage.Width - 1; x++)
                {
                    TestPoint.X = x;
                    TestPoint.Y = y;

                    if (TrianglePath.IsVisible(TestPoint))
                        TriangleImage.SetPixel(x, y, GetGradedColorAtPoint(TestPoint));
                }
            }
            pictureBox.Image = TriangleImage;
        }

        public static Color GetGradedColorAtPoint(Point point)
        {
            int R = (int)Math.Round(THeight) - point.Y;
            int B = (int)Math.Round(Math.Sin(Rad60) * (point.X - R / Math.Tan(Rad60)));
            int G = 255 - B - R;
            return Color.FromArgb(R, G, B);
        }
    }
}
