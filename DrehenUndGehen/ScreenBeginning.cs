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
    public partial class ScreenBeginning : Form
    {
        public ScreenBeginning()
        {
            InitializeComponent();
        }

        private void ScreenBeginning_Load(object sender, EventArgs e)
        {
            Bitmap back = new Bitmap("background4.bmp");
            this.Width = back.Width;
            this.Height = back.Height;
            this.BackgroundImage = back;

            btnStartGame.Location = new Point(((this.Width/2)-(btnStartGame.Width/2)), this.Height/3 * 2);
            btnInstruction.Location = new Point(((this.Width / 2) - (btnStartGame.Width / 2)), (this.Height / 3 * 2 + btnStartGame.Height +4));
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
           //  Bitmap instruction = new Bitmap("instruction.bmp");

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Characters figures = new Characters();
            this.Visible = false;

            figures.Visible = true;
        }

        private void ScreenBeginning_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
