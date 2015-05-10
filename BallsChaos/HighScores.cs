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
    public partial class HighScores : Form
    {
        public List<Player> players;
        public HighScores(List<Player> players)
        {
            InitializeComponent();
            this.players = players;
            najdobri();
        }
        private void najdobri()
        {
            players = players.OrderByDescending(x => x.points).ToList();
            for (int i = 0; i < players.Count; i++)
            {
                lbBestPlayers.Items.Add(players[i]);
            }

        }
        private void HighScores_Paint(object sender, PaintEventArgs e)
        {
            // this.BackgroundImage = Resources.sky;
        }

        private void label2_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
