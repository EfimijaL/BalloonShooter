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
    public partial class ExitGame : Form
    {
        public bool exit = false;
        public ExitGame()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            exit = true;
            Close();
        }


    }
}
