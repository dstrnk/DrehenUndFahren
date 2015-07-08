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
    public partial class Characters : Form
    {
        Bitmap LordKnight;
        Bitmap Marian;
        Bitmap NinjaJustin;
        Bitmap SirDavid;
        Bitmap KingPatrick;
        Bitmap PopeRoman;
        public int playerOne { get; set; }
        public int playerTwo {get; set; }


        int playerReady;

        public Characters()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            playerReady = 0;

            Player Knight = new Player(0, new Point(0,0));
            LordKnight = Knight.getFrontBitmap();

            Player Woman = new Player(1, new Point(0, 0));
            Marian = Woman.getFrontBitmap();

            Player Ninja = new Player(2, new Point(0, 0));
            NinjaJustin = Ninja.getFrontBitmap();

            Player Sir = new Player(3, new Point(0, 0));
            SirDavid = Sir.getFrontBitmap();

            Player King = new Player(4, new Point(0, 0));
            KingPatrick = King.getFrontBitmap();

            Player Pope = new Player(5, new Point(0, 0));
            PopeRoman = Pope.getFrontBitmap();            
                    

            fillPictureBoxes();
        }

        private void Characters_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap("background4.bmp");
        }

        public void fillPictureBoxes()
        {
            pbChar1.BackgroundImage = LordKnight;
            pbChar2.BackgroundImage = Marian;
            pbChar3.BackgroundImage = NinjaJustin;
            pbChar4.BackgroundImage = SirDavid;
            pbChar5.BackgroundImage = KingPatrick;
            pbChar6.BackgroundImage = PopeRoman;

        }

        public Bitmap makePlayerImageGrey(Bitmap bmp)
        {
            Color PixRGB;
            Color PixSW;

            int temp;
            for (int sp = 0; sp < bmp.Width; sp++)
            {
                for (int zei = 0; zei < bmp.Height; zei++)
                {
                    PixRGB = bmp.GetPixel(sp, zei);
                    temp = (PixRGB.R + PixRGB.G + PixRGB.B) / 3;
                    PixSW = Color.FromArgb(temp, temp, temp);
                    bmp.SetPixel(sp, zei, PixSW);
                }
            }

            return bmp;
        }

        

        private void btnbereit_Click_1(object sender, EventArgs e)
        {
            playerReady++;

            if (playerReady == 1)
            {
                if (rbLordKnight.Checked == true)
                {

                    rbLordKnight.Enabled = false;
                    pbChar1.BackgroundImage = makePlayerImageGrey(LordKnight);
                    playerOne = 2;



                }
                else if (rbMarian.Checked == true)
                {

                    rbMarian.Enabled = false;
                    pbChar2.BackgroundImage = makePlayerImageGrey(Marian);
                    playerOne = 5;

                }
                else if (rbNinjaJustin.Checked == true)
                {

                    rbNinjaJustin.Enabled = false;
                    pbChar3.BackgroundImage = makePlayerImageGrey(NinjaJustin);
                    playerOne = 6;

                }
                else if (rbSirDavid.Checked == true)
                {

                    rbSirDavid.Enabled = false;
                    pbChar4.BackgroundImage = makePlayerImageGrey(SirDavid);
                    playerOne = 8;

                }
                else if (rbKingPatrick.Checked == true)
                {

                    rbKingPatrick.Enabled = false;
                    pbChar5.BackgroundImage = makePlayerImageGrey(KingPatrick);
                    playerOne = 3;

                }
                else if (rbPopeRoman.Checked == true)
                {

                    rbPopeRoman.Enabled = false;
                    pbChar6.BackgroundImage = makePlayerImageGrey(PopeRoman);
                    playerOne = 1;


                }

               
                btnbereit.Text = "Spieler 2 ready!";

                

                if (rbLordKnight.Checked == true)
                {
                    rbMarian.Checked = true;
                }
                else
                {
                    rbLordKnight.Checked = true;
                }

            }
            else if (playerReady == 2)
            {
                if (rbLordKnight.Checked == true)
                {

                    rbLordKnight.Enabled = false;
                    pbChar1.Image = makePlayerImageGrey(LordKnight);
                    playerTwo = 2;

                }
                else if (rbMarian.Checked == true)
                {
                    rbMarian.Enabled = false;
                    pbChar2.Image = makePlayerImageGrey(Marian);
                    playerTwo = 5;

                }
                else if (rbNinjaJustin.Checked == true)
                {

                    rbNinjaJustin.Enabled = false;
                    pbChar3.Image = makePlayerImageGrey(NinjaJustin);
                    playerTwo = 6;
                }
                else if (rbSirDavid.Checked == true)
                {

                    rbSirDavid.Enabled = false;
                    pbChar4.Image = makePlayerImageGrey(SirDavid);
                    playerTwo = 8;
                }
                else if (rbKingPatrick.Checked == true)
                {

                    rbKingPatrick.Enabled = false;
                    pbChar5.Image = makePlayerImageGrey(KingPatrick);
                    playerTwo = 3;
                }
                else if (rbPopeRoman.Checked == true)
                {

                    rbPopeRoman.Enabled = false;
                    pbChar6.Image = makePlayerImageGrey(PopeRoman);
                    playerTwo = 1;


                }

                btnNext.Visible = true;
                btnbereit.Visible = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MapEditor map = new MapEditor(playerOne, playerTwo);
            this.Visible = false;
            map.Visible = true;
        }

        private void pbChar1_Click(object sender, EventArgs e)
        {

        }

        private void Characters_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }




    }
}
