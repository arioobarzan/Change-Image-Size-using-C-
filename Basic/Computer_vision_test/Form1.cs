using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_vision_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string t1 = textBox1.Text;
            string t2 = textBox2.Text;

            int x = int.Parse(t1);
            int y = int.Parse(t2);

            Bitmap bmp = new Bitmap(500,300);

            pictureBox1.Image = bmp;
            Color c = Color.FromArgb(255,128,0);
            /*
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    bmp.SetPixel(x + i, y + j, c);
                }
            }*/
            
        }
    }
}