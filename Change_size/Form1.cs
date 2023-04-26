using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Change_size
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
            pictureBox2.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Bitmap original = (Bitmap)pictureBox2.Image;
            int w = original.Width;
            int h = original.Height;
            Bitmap resized = new Bitmap(x, y);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int i2 = (int)Math.Floor(Decimal.Multiply(i, Decimal.Divide(w, x)));
                    int j2 = (int)Math.Floor(Decimal.Multiply(j, Decimal.Divide(h, y)));
                    Color c = original.GetPixel(i2, j2);
                    resized.SetPixel(i, j, c);
                }
            }
            pictureBox1.Size = new Size(x, y);
            pictureBox1.Image = resized;

        }
    }
}