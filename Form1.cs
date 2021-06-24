using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayPractice
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();

        const int labelmax = 10;
        int []vx = new int[labelmax];
        int []vy = new int[labelmax];
        int score = 100;
        int i;
        Label[] labels = new Label[labelmax];

        public Form1()
        {
            InitializeComponent();

            for(i = 0; i < labelmax; i++)
            {
                vx[i] = rand.Next(-20, 21);
                vy[i] = rand.Next(-20, 21);

                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "( ﾟДﾟ)ﾅﾝﾀﾞｯﾃ!?";
                Controls.Add(labels[i]);

                labels[i].Left = rand.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = rand.Next(ClientSize.Height - labels[i].Height);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score--;
            scoreLabel.Text = $"Score {score:000}";

            for (i = 0; i < labelmax; i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];

                if (labels[i].Left < 0)
                {
                    vx[i] = Math.Abs(vx[i]);
                }
                if (labels[i].Top < 0)
                {
                    vy[i] = Math.Abs(vy[i]);
                }
                if (labels[i].Right > ClientSize.Width)
                {
                    vx[i] = -Math.Abs(vx[i]);
                }
                if (labels[i].Bottom > ClientSize.Height)
                {
                    vy[i] = -Math.Abs(vy[i]);
                }
            }

            Point fpos = PointToClient(MousePosition);

            for(i = 0; i < labelmax; i++)
            {
                if ((fpos.X >= labels[i].Left)
                && (fpos.X < labels[i].Right)
                && (fpos.Y >= labels[i].Top)
                && (fpos.Y < labels[i].Bottom))
                {
                    labels[i].Visible = false;
                }
            }
            if ((labels[0].Visible == false)
                && (labels[1].Visible == false)
                && (labels[2].Visible == false)
                && (labels[4].Visible == false)
                && (labels[5].Visible == false)
                && (labels[6].Visible == false)
                && (labels[7].Visible == false)
                && (labels[8].Visible == false)
                && (labels[9].Visible == false))
            {
                    timer1.Enabled = false;
            }
        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                if(i % 2 == 0)
                {
                    continue;
                }
                if (i == 9)
                {
                    break;
                }
                MessageBox.Show("" + i);
            }
        }
    }
}