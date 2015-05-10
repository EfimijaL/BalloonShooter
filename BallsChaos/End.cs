using BallsChaos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BallsChaos
{
    public partial class End : Form
    {
        public int rezultat;
        Player igrac;
        List<Player> niza;
        public End(int rez,Player i,List<Player> n)
        {
            InitializeComponent();
            rezultat = rez;
            niza = n;
            igrac = i;
            label3.Text = rez.ToString();
        }
        public End()
        {

        }
        private void End_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Player igrac1 = new Player(textBox1.Text, rezultat);
            niza.Add(igrac1);
            HighScores h = new HighScores(niza);
            this.Close();
            h.ShowDialog();

        }
    }
}
