using System;
using System.Windows.Forms;

namespace TriangleMaksvel
{
    public partial class Form1 : Form
    {
        private bool brightTriangle = false;
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
            TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);

        }

        private void IncreaseButton_Click(object sender, System.EventArgs e)
        {
            uxPictureBox.Width += 10;
            TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);
            PlaceCenter();
        }

        private void ReduceButton_Click(object sender, System.EventArgs e)
        {
            uxPictureBox.Width -= 10;
            TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);
            PlaceCenter();
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            PlaceCenter();
        }

        private void PlaceCenter()
        {
            int X = (int)Math.Round((Width / 2d) - (uxPictureBox.Width / 2d));
            int Y = (int)Math.Round((Height / 2d) - (uxPictureBox.Height / 2d));

            uxPictureBox.Location = new System.Drawing.Point(X, Y);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedItem)
            {
                case "Яркий":
                    brightTriangle = true;
                    break;
                case "Нормальный":
                    brightTriangle = false;
                    break;
            }
            TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);
        }
    }
}
