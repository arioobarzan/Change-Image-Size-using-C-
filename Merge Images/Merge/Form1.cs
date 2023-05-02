using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            string file = "";
            if (op.ShowDialog() == DialogResult.OK)
                file = op.FileName;
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            string file = "";
            if (op.ShowDialog() == DialogResult.OK)
                file = op.FileName;
            Bitmap bmp = new Bitmap(file);
            pictureBox2.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox1.Image;
            Bitmap bmp2 = (Bitmap)pictureBox2.Image;
            int w = bmp1.Width;
            int h = bmp1.Height;
            Bitmap bmp3 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color c1 = bmp1.GetPixel(i, j);
                    Color c2 = bmp2.GetPixel(i, j);

                    int r = (c1.R + c2.R) / 2;
                    int g = (c1.G + c2.G) / 2;
                    int b = (c1.B + c2.B) / 2;

                    Color c3 = Color.FromArgb(r,g,b);

                    bmp3.SetPixel(i, j, c3);

                }
            }
            pictureBox3.Image = bmp3;
        }
    }
}
