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
            LordKnight = new Bitmap(Knight.getFrontBitmap(), pbChar1.Width, pbChar1.Height);


            Player Woman = new Player(1, new Point(0, 0));
            Marian = new Bitmap(Woman.getFrontBitmap(), pbChar2.Width, pbChar2.Height);

            Player Ninja = new Player(2, new Point(0, 0));
            NinjaJustin = new Bitmap(Ninja.getFrontBitmap(), pbChar3.Width, pbChar3.Height);

            Player Sir = new Player(3, new Point(0, 0));
            SirDavid = new Bitmap(Sir.getFrontBitmap(), pbChar4.Width, pbChar4.Height);

            Player King = new Player(4, new Point(0, 0));
            KingPatrick = new Bitmap(King.getFrontBitmap(), pbChar5.Width, pbChar5.Height);

            Player Pope = new Player(5, new Point(0, 0));
            PopeRoman = new Bitmap(Pope.getFrontBitmap(), pbChar6.Width, pbChar6.Height);            
                    

            fillPictureBoxes();
        }

        private void Characters_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap("background4.bmp");
        }

        public void fillPictureBoxes()
        {
            pbChar1.Image = LordKnight;
            pbChar2.Image = Marian;
            pbChar3.Image = NinjaJustin;
            pbChar4.Image = SirDavid;
            pbChar5.Image = KingPatrick;
            pbChar6.Image = PopeRoman;

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
            Bitmap temp;
            if (playerReady == 1)
            {
                if (rbLordKnight.Checked == true)
                {
                    //Wird geladen und dann der schwarze Hintergrund ausgeblendet
                    rbLordKnight.Enabled = false;
                    temp = makePlayerImageGrey(LordKnight);
                    temp.MakeTransparent(Color.Black);
                    pbChar1.Image = temp;
                    playerOne = 0;



                }
                else if (rbMarian.Checked == true)
                {

                    rbMarian.Enabled = false;
                    temp = makePlayerImageGrey(Marian);
                    temp.MakeTransparent(Color.Black);
                    pbChar2.Image = temp;
                    playerOne = 1;

                }
                else if (rbNinjaJustin.Checked == true)
                {

                    rbNinjaJustin.Enabled = false;
                    temp = makePlayerImageGrey(NinjaJustin);
                    temp.MakeTransparent(Color.Black);
                    pbChar3.Image = temp;
                    playerOne = 2;

                }
                else if (rbSirDavid.Checked == true)
                {

                    rbSirDavid.Enabled = false;
                    temp = makePlayerImageGrey(SirDavid);
                    temp.MakeTransparent(Color.Black);
                    pbChar4.Image = temp;
                    playerOne = 3;

                }
                else if (rbKingPatrick.Checked == true)
                {

                    rbKingPatrick.Enabled = false;
                    temp = makePlayerImageGrey(KingPatrick);
                    temp.MakeTransparent(Color.Black);
                    pbChar5.Image = temp;
                    playerOne = 4;

                }
                else if (rbPopeRoman.Checked == true)
                {

                    rbPopeRoman.Enabled = false;
                    temp = makePlayerImageGrey(PopeRoman);
                    temp.MakeTransparent(Color.Black);
                    pbChar6.Image = temp;
                    playerOne = 5;


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
                    temp = makePlayerImageGrey(LordKnight);
                    temp.MakeTransparent(Color.Black);
                    pbChar1.Image = temp;
                    playerTwo = 0;

                }
                else if (rbMarian.Checked == true)
                {
                    rbMarian.Enabled = false;
                    temp = makePlayerImageGrey(Marian);
                    temp.MakeTransparent(Color.Black);
                    pbChar2.Image = temp;
             
                    playerTwo = 1;

                }
                else if (rbNinjaJustin.Checked == true)
                {

                    rbNinjaJustin.Enabled = false;
                    temp = makePlayerImageGrey(NinjaJustin);
                    temp.MakeTransparent(Color.Black);
                    pbChar3.Image = temp;
                    playerTwo = 2;
                }
                else if (rbSirDavid.Checked == true)
                {

                    rbSirDavid.Enabled = false;
                    temp = makePlayerImageGrey(SirDavid);
                    temp.MakeTransparent(Color.Black);
                    pbChar4.Image = temp;
                    playerTwo = 3;
                }
                else if (rbKingPatrick.Checked == true)
                {

                    rbKingPatrick.Enabled = false;
                    temp = makePlayerImageGrey(KingPatrick);
                    temp.MakeTransparent(Color.Black);
                    pbChar5.Image = temp;
                    playerTwo = 4;
                }
                else if (rbPopeRoman.Checked == true)
                {

                    rbPopeRoman.Enabled = false;
                    temp = makePlayerImageGrey(PopeRoman);
                    temp.MakeTransparent(Color.Black);
                    pbChar6.Image = temp;
                    playerTwo = 5;


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

        private void rbLordKnight_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbKingPatrick_CheckedChanged(object sender, EventArgs e)
        {

        }




    }
}
