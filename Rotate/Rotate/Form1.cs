using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rotate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            int w = bmp.Width;
            int h = bmp.Height;
            Bitmap new_bmp = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color c = bmp.GetPixel(w - i - 1, h - j - 1);
                    new_bmp.SetPixel(i, j, c);
                }
            }
            pictureBox2.Image = new_bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            string file = "";
            if (op.ShowDialog() == DialogResult.OK)
                file = op.FileName;

            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            int w = bmp.Width;
            int h = bmp.Height;
            Bitmap new_bmp = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color c = bmp.GetPixel(w - i - 1, j);
                    new_bmp.SetPixel(i, j, c);
                }
            }
            pictureBox2.Image = new_bmp;
        }
    }
}
