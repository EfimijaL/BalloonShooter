using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BallsChaos.Properties;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BallsChaos
{
    [Serializable]
    public class Ball
    {
        private static readonly int RADIUS = 20;

        public Point Center { get; set; }

        public Color Color { get; set; }
        public bool bomba { get; set; }
        public Image slika { get; set; }
        Image [] niza;
        public double Velocity { get; set; }
        public double Angle { get; set; }

        private float velocityX;
        private float velocityY;

        public bool Flag { get; set; }

        public bool IsColided { get; set; }

        public Ball(Point center, Color color,Image s)
        {
            Center = center;
            Color = color;
            niza = new Image[4];
            niza[0] = Resources._123213;
            niza[1] = Resources._33;
            niza[2] = Resources.sss;
            niza[3] = Resources.Untitled;
            
            IsColided = false;
            slika = s;
            Velocity = 10;
            Random r = new Random();
            Angle = r.NextDouble() * 2 * Math.PI;
            velocityX = (float)(90 * Velocity);
            velocityY = (float)(90 * Velocity);
            Flag = false;
        }

        public void Draw(Graphics g)
        {
            
            g.DrawImageUnscaled(slika, Center);
           
        }

        public  bool IsHit(float x, float y)
        {
            Point nova = new Point((int)x, (int) y);

            if (nova.Y <= (Center.Y + 90) && nova.Y >= (Center.Y ))
            {
                if (nova.X <= (Center.X + 65) && nova.X >= (Center.X))
                    return true;
                else return false;
            }
            else
                return false;
        

        }

        public bool Missed()
        {
            if (bomba && Center.Y == -100)
                return false;

            else if(Center.Y==-100)
            {
                return true;
            }
            else
                return false;
        }


        public void Move()
        {
            float nextX = Center.X + 30;
            float nextY = Center.Y + 30;
            
            Center = new Point((int)(Center.X), (int)(Center.Y-10));          
        }


        private Ball(SerializationInfo info, StreamingContext context)
        {


            Center = (Point)info.GetValue("Center", typeof(Point));
            Color = (Color)info.GetValue("Color", typeof(Color));
            slika = (Image)info.GetValue("Slika", typeof(Image));

        }

        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
           

            inf.AddValue("Center", Center);
            inf.AddValue("Colour", Color);
            inf.AddValue("Slika", slika);


        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Center: {0}\r\n", Center);
            str.AppendFormat("Colour: {0}\r\n", Color);
            str.AppendFormat("Slika: {0}\r\n", slika);
            return str.ToString();
        }

    }
}
