using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrehenUndGehen
{
    public partial class MapEditor : Form
    {
        int anzItems;
        int playerOne;
        int playerTwo;
        int mapSize;
        String whoBegins;

        public MapEditor(int p1, int p2)
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            playerOne = p1;
            playerTwo = p2;
            anzItems = 0;
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap("background4.bmp");
        }

 

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            // würfeln 

            Random wuerfel = new Random();
            int a = wuerfel.Next(1,100);
            int b = wuerfel.Next(1, 100);

            if(a>b)
            {
                whoBegins = "playerOne";
            }
            else if (b>a)
            {
                whoBegins = "playerTwo";
            }
            else
            {
                whoBegins = "playerOne";
            }

            if (rbEinfach.Checked)
            {
                mapSize = 7;

            }else if (rbMittel.Checked)
            {
                mapSize = 9;
            }
            else if (rbSchwer.Checked)
            {
                mapSize = 11;
            }
            if (rbviele.Checked == true)
            {
                anzItems = 3;
            }
            else if(rbwenige.Checked == true)
            {
                anzItems = 8;
            }
            else if (rbnormal.Checked == true)
            {
                anzItems = 5;
            }

            Form1 game = new Form1(mapSize, playerOne, playerTwo, anzItems, whoBegins);
            game.Visible = true;


        }

        private void rbEinfach_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                Bitmap Bild = new Bitmap ("map7.png");
                pbMap.BackgroundImage = new Bitmap (Bild, 251, 237);
            }
        }

        private void rbMittel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                Bitmap Bild = new Bitmap("map9.png");
                pbMap.BackgroundImage = new Bitmap(Bild, 251, 237);
            }
        }

        private void rbSchwer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                Bitmap Bild = new Bitmap("map11.png");
                pbMap.BackgroundImage = new Bitmap(Bild, 251, 237);
            }
        }

        private void MapEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
