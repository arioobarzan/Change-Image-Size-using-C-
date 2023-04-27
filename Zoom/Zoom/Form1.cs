using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoom
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
            string filename = "";
            if (op.ShowDialog() == DialogResult.OK)
                filename = op.FileName;

            Bitmap bmp = new Bitmap(filename);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox1.Image;
            int w1 = bmp1.Width;
            int h1 = bmp1.Height;
            int w2 = w1 * 2;
            int h2 = h1 * 2;
            Bitmap bmp2 = new Bitmap(w2, h2);

            for (int i = 0; i < w1; i++)
            {
                for (int j = 0; j < h1; j++)
                {
                    Color c = bmp1.GetPixel(i, j);
                    int i2 = i * 2;
                    int j2 = j * 2;
                    bmp2.SetPixel(i2, j2, c);
                    //bmp2.SetPixel(i2 + 1, j2, c);
                    //bmp2.SetPixel(i2, j2 + 1, c);
                    //bmp2.SetPixel(i2 + 1, j2 + 1, c);
                }
            }
            pictureBox2.Image = bmp2;
        }
    }
}
