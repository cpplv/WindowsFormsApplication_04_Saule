using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int N = 0;
        PictureBox[] P;
        Random rrr = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            int k, x, y;
            for (k = 0; k < N; k++)
                if (P[k].ImageLocation == "sun.jpg")
                {
                    do
                    {
                        x = P[k].Left + rrr.Next(-20, 20);
                        y = P[k].Top + rrr.Next(-20, 20);
                    }
                    while (x < 10 || y < 10 || x > groupBox1.Width - 20 || y > groupBox1.Height - 20);
                    P[k].Left = x;
                    P[k].Top = y;
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k;
            try
            {
                N = int.Parse(textBox1.Text);
            }
            catch { };
            if (N < 1) N = 1;
            else if (N > 10) N = 10;
            textBox1.Text = N.ToString();
            textBox1.Enabled = false;
            button1.Enabled = false;
            P = new PictureBox[N];
            for (k = 0; k < N; k++)
            {
                P[k] = new PictureBox();
                P[k].Parent = groupBox1;
                P[k].Width = 50;
                P[k].Height = 50;
                P[k].Top = rrr.Next(10, groupBox1.Height - 60);
                P[k].Left = rrr.Next(10, groupBox1.Width - 60);
                P[k].ImageLocation = "sun.jpg";
                P[k].Load();
                P[k].Click += new EventHandler(PicClick);
            }
            timer1.Enabled = true;
        }

        protected void PicClick(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.ImageLocation = "moon.jpg";
            p.Load();
            p.SendToBack();
        }
    }
}
