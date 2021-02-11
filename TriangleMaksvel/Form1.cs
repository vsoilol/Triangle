using System.Windows.Forms;

namespace TriangleMaksvel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            TriangleColor.DrawColorTriangle(uxPictureBox);
        }
    }
}
