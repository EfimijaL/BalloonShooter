using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BallsChaos.Properties;
using System.Media;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BallsChaos
{
    [Serializable]
    public class BallList
    {
        public List<Ball> Balls { get; set; }
        public int points { get; set; }
        private SoundPlayer[] sounds;

        public BallList()
        {
            Balls = new List<Ball>();
            points = 0;
            sounds = new SoundPlayer[8];
            sounds[0] = new System.Media.SoundPlayer(Resources._1);
            sounds[1] = new System.Media.SoundPlayer(Resources._2);
            sounds[2] = new System.Media.SoundPlayer(Resources._3);
            sounds[3] = new System.Media.SoundPlayer(Resources._4);
            sounds[4] = new System.Media.SoundPlayer(Resources._5);
            sounds[5] = new System.Media.SoundPlayer(Resources._6);
            sounds[6] = new System.Media.SoundPlayer(Resources.Snip_lose_01);
            sounds[7] = new System.Media.SoundPlayer(Resources.ringtone);
           
        }

        public void Draw(Graphics g)
        {
            foreach (Ball ball in Balls)
            {
                ball.Draw(g);
            }
        }

        public void AddBall(Ball ball)
        {
            Balls.Add(ball);
        }

        public void MoveBalls()
        {
            foreach (Ball ball in Balls)
            {
                ball.Move();
            }
        }

        public bool CheckMissed()
        {
            bool brojac = false;
            foreach (Ball ball in Balls)
            {
                if(ball.Missed())
                {
                    brojac = true;
                }
            }

            return brojac;
        }

       

        public void CheckForExplosions(float x,float y)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                for (int j = i + 1; j < Balls.Count; j++)
                {
                    if (Balls[i].IsHit(x,y))
                    {
                        Balls[i].Flag = true;
                        
                    }
                }
            }
            for (int i = Balls.Count - 1; i >= 0; i--)
            {
                if (Balls[i].Flag)
                {
                    if (Balls[i].bomba == true)
                    {

                        sounds[0].Play();
                        points -= 5;
                    }
                    else
                    {
                        Random random = new Random();
                        int ran = random.Next(1, 5);
                        sounds[ran].Play();
                        points += 10;
                    }
                    Balls.RemoveAt(i);

                }
                else
                {
                    sounds[7].Play();
                }   
            }
            
        }

        private BallList(SerializationInfo info, StreamingContext context)
        {
           
            if (Balls != null && points != 0 && sounds != null)
            {
                Balls = (List<Ball>)info.GetValue("Balls:", typeof(List<Ball>));
                points = (int)info.GetValue("Points:", typeof(int));
                sounds = (SoundPlayer[])info.GetValue("Sounds:", typeof(SoundPlayer[]));
            }

        }

        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
            
            inf.AddValue("Balls", Balls);
            inf.AddValue("Points", points);
            inf.AddValue("Sounds", sounds);


        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Balls: \n ");
            for (int i = 0; i < Balls.Count; i++)
            {

                str.AppendFormat("{0} ", Balls[i]);
                if (i == Balls.Count - 1)
                    str.AppendFormat(", \t\n");
            }
            str.AppendFormat("Points: {0}\r\n", points);
            str.AppendFormat("Sounds: ");
            for (int j = 0; j < sounds.Count(); j++)
            {

                str.AppendFormat("{0} ", sounds[j]);
                if (j == sounds.Count() - 1)
                    str.AppendFormat(", \t\n");
            }
            return str.ToString();
        }

       

     
    }
}
