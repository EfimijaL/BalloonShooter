using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BallsChaos.Properties;

namespace BallsChaos
{
    public partial class Form1 : Form
    {
        private BallList doc;
        
        private Color currentColor;

        private int width;
        private int height;

        private Timer timer;

        private int flag = 0;
     
        private int different;

        private int count1;
        private int zname = 0;
        Image Ballon;
        List<Player> niza1;
        Image Sky;
        Cursor myCursor;
        public string nivo;
        Player igrac;
        private int count;
        private Image [] niza;

        public Form1(string nivo1,Player i,List<Player> n)
        {
            InitializeComponent();
            doc = new BallList();
            niza = new Image[4];
            niza[0] = Resources._123213;
            niza[1] = Resources._33;
            niza[2] = Resources.sss;
            niza[3] = Resources.Untitled;
            
            if (String.IsNullOrEmpty(nivo1))
            {
                nivo = "Easy";
            }
            else
            {
                nivo = nivo1;
            }
            igrac = i;
            niza1 = n;
            currentColor = Color.Red;
            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
          
            timer.Start();
            timer1.Enabled = true;
           
            timer1.Start();
           
            using (var memoryStream = new MemoryStream(Properties.Resources.target__4_))
            {
                this.Cursor = new Cursor(memoryStream);
            }
            width = 950;
            height = 500;
            Sky = Resources.sky;
            this.BackgroundImage=Sky;
            Ballon = Resources._123213;
          
        }

        void timer_Tick(object sender, EventArgs e)
        {
            
            doc.MoveBalls();

            if (verticalProgressBar1.Value <= 95)
            {
                if (doc.CheckMissed())
                {
                    verticalProgressBar1.Value += 5;
                }
            }
            else
            {
                if (doc.CheckMissed())
                {
                    verticalProgressBar1.Value = 100;
                }
            }
           
            if(nivo.Equals("Easy"))
            {
            if (count1 <= 30)
            {
                if (count % 25 == 0)
                {
                    Random random = new Random();

                    Point newLocation = new Point(random.Next(100, this.width - 230), height);
                    int x = random.Next(0, 4);
                    Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                    if (x == 1)
                        nov.bomba = true;
                    doc.AddBall(nov);

                }
            }
            else if(count1 > 30 && count < 90)
            {
                if (count % 20 == 0)
                {
                    Random random = new Random();
                    Point newLocation = new Point(random.Next(70, this.Width - 150), height);
                    int x = random.Next(0, 4);
                    Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                    if (x == 1)
                        nov.bomba = true;
                    doc.AddBall(nov);

                }
            }
            else
            {
                if (count % 15 == 0)
                {
                    Random random = new Random();
                    Point newLocation = new Point(random.Next(70, this.Width - 150), height);
                    int x = random.Next(0, 4);
                    Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                    if (x == 1)
                        nov.bomba = true;
                    doc.AddBall(nov);

                }
            }
          }
            else if(nivo.Equals("Medium"))
            {
                if (count1 <= 30)
                {
                    if (count % 20 == 0)
                    {
                        Random random = new Random();

                        Point newLocation = new Point(random.Next(70, this.width - 150), height);
                        int x = random.Next(0, 4);
                        Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                        if (x == 1)
                            nov.bomba = true;
                        doc.AddBall(nov);

                    }
                }
                else if (count1 > 30 && count < 90)
                {
                    if (count % 15 == 0)
                    {
                        Random random = new Random();
                        Point newLocation = new Point(random.Next(70, this.Width - 150), height);
                        int x = random.Next(0, 4);
                        Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                        if (x == 1)
                            nov.bomba = true;
                        doc.AddBall(nov);

                    }
                }
                else
                {
                    if (count % 10 == 0)
                    {
                        Random random = new Random();
                        Point newLocation = new Point(random.Next(70, this.Width - 150), height);
                        int x = random.Next(0, 4);
                        Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                        if (x == 1)
                            nov.bomba = true;
                        doc.AddBall(nov);

                    }
                }
            }
            else
            {
                if (count1 <= 30)
                {
                    if (count % 15 == 0)
                    {
                        Random random = new Random();

                        Point newLocation = new Point(random.Next(70, this.width - 150), height);
                        int x = random.Next(0, 4);
                        Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                        if (x == 1)
                            nov.bomba = true;
                        doc.AddBall(nov);

                    }
                }
                else if (count1 > 30 && count < 90)
                {
                    if (count % 10 == 0)
                    {
                        Random random = new Random();
                        Point newLocation = new Point(random.Next(70, this.Width - 150), height);
                        int x = random.Next(0, 4);
                        Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                        if (x == 1)
                            nov.bomba = true;
                        doc.AddBall(nov);

                    }
                }
                else
                {
                    if (count % 5 == 0)
                    {
                        Random random = new Random();
                        Point newLocation = new Point(random.Next(70, this.Width - 150), height);
                        int x = random.Next(0, 4);
                        Ball nov = new Ball(newLocation, Color.Red, niza[x]);
                        if (x == 1)
                            nov.bomba = true;
                        doc.AddBall(nov);

                    }
                }
            }
            count++;

          
            Invalidate(true);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {     
                doc.Draw(e.Graphics); 
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (zname == 0)
            {
                doc.CheckForExplosions(e.X, e.Y);
                lblPoints.Text = doc.points.ToString();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           

            if (verticalProgressBar1.Value < 100)
            {
                verticalProgressBar1.Value++;
            }
            else if(verticalProgressBar1.Value==100)
            {
                timer.Stop();
                timer1.Stop();
                System.Media.SoundPlayer s = new System.Media.SoundPlayer(Resources.Snip_lose_01);
                s.Play();
                End novo1 = new End(Convert.ToInt16(lblPoints.Text), igrac, niza1);
                this.Close();
                novo1.ShowDialog();
            }
            count1++;
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (zname == 0)
            {
                timer1.Stop();
                timer.Stop();
                pbPause.Image = Resources.play1;
                zname = 1;
                label1.Visible = true;
            }
            else
            {
                timer.Start();
                timer1.Start();
                pbPause.Image = Resources.pause1;
                zname = 0;
                label1.Visible = false;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            timer.Stop();
            ExitGame x = new ExitGame();
            x.ShowDialog();
            if (x.exit == true)
            {
                Close();
            }
            else
            {
                timer.Start();
                timer1.Start();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            verticalProgressBar1.Value = 0;
            timer.Stop();
            timer1.Stop();
        }

        

      

      
    }
}
