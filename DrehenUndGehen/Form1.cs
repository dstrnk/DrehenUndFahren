using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;

namespace DrehenUndGehen
{
	public partial class Form1 : Form
	{
		Graphics g;
		Map first;
		Renderer rend;
		bool moving, push,mouseover;
		
		Point p;
		int row = -1; 
		int column = -1;
		int pixeloffset = 0;
		Gamescreen screen;
		
		public Form1()
		{
			InitializeComponent();
			first = new Map(7);

			screen = new Gamescreen(first, this);
			first.fillMap();			
			first.addPropToMap(first);			
					            //Fenster wird auto Maximiert
			this.DoubleBuffered = true;                                     //Reduziert flimmern hierdurch kann allerdings nur im on_paint event gezeichnet werden    
            this.AllowDrop = true;											//für Drag and Drop bin mir aber nicht sicher ob es Programmintern überhaupt gebraucht wird
			p = new Point(screen.ExchangeCard.X, screen.ExchangeCard.Y);
			WindowState = FormWindowState.Maximized;
			
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		public void Form1_Paint(object sender, PaintEventArgs e)
		{

			g = e.Graphics;
			
			
			
			rend = new Renderer(first, g,screen);
			rend.drawBackground(mouseover);
			rend.drawPropToFind();


			if (moving == true)
			{
				rend.drawMarks(new Point(p.X + screen.MapPointSize / 2, p.Y + screen.MapPointSize / 2));
			}
			if (column == -1 && row == -1)
			{
				rend.drawMap();
				if (moving == true)
				{
					rend.drawMovingExCard(p.X, p.Y);
				}
				else
					rend.drawExchangeCard();
			}
			else
			{
				rend.drawMap(pixeloffset,push,row,column);
				rend.drawExchangeCard(pixeloffset,push,row,column);
			}
            rend.drawPlayer();
	
			
			
		
			
		}

		private void Form1_Shown(object sender, EventArgs e)
		{


		}


		public void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (screen.Button.Contains(e.Location))
			{
				first.switchPosition(first.exchangeCard);
				mouseover = true;
				Invalidate(screen.Button);
			}
			
			if(e.Button==MouseButtons.Left&&screen.ExchangeCard.Contains(e.Location))         // Überprüfung ob sich die Maus auf der exchangeCard Befindet
			{
				p.X = e.X - screen.MapPointSize / 2;                                                                                         // Falls ja wird die Maus in die Mitte der exchangeCard gesetzt
				p.Y = e.Y - screen.MapPointSize / 2;                                                                                     // und moving wird auf true gesetzt
				moving = true;
			}
					
		}

		public void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			
			if (moving)                                                                                                                // wenn die Maus sich bewegt während moving true(also der Maus nicht losgelassen wurde) ist.
			{
				p.X = e.X - screen.MapPointSize / 2;                                                                                       // Wird die exchange card immer an die Position der Maus gezeichnet
				p.Y = e.Y - screen.MapPointSize / 2;                                                                                         // Drag and Drop halt....
				Refresh();
			}
			
			
								
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{	/*
             * Hier wird überprüft ob die exchangeCard auf der richtigen Position abgelegt wurde(Rote Pfeile)
             * falls ja wird die Reihe/Spalte entsprechend verschoben
             */ 
            if (moving)
            {
                for (int i = 0; i < first.Mapsize; i++)
                {
                    if (i % 2 != 0)
                    {
						if (new RectangleF(screen.MapPosition.X - screen.MapPointSize, screen.MapPosition.Y + screen.MapPointSize * i, screen.MapPointSize, screen.MapPointSize).Contains(e.Location))
                        {
							push = true;
							row = i;
							timer1.Enabled = true;							
							timer1.Interval = 50;
							first.files.player.Play();
							//timer1.Start();
							//first.PushRow(i, first.exchangeCard);
						 					   
	 
                        }
						else if (new RectangleF(screen.MapPosition.X + screen.MapPointSize * i, screen.MapPosition.Y - screen.MapPointSize, screen.MapPointSize, screen.MapPointSize).Contains(e.Location))
                        {
							push = true;
							column = i;
							timer1.Enabled = true;
							timer1.Interval = 50;
							first.files.player.Play();

                            //first.PushColumn(i, first.exchangeCard);
                            //Refresh();
                        }
						else if (new RectangleF(screen.MapPosition.X + screen.MapPointSize * first.Mapsize, screen.MapPosition.Y + screen.MapPointSize * i, screen.MapPointSize, screen.MapPointSize).Contains(e.Location))
                        {
							push = false;
							row = i;
							timer1.Enabled = true;
							timer1.Interval = 50;
							first.files.player.Play();
                            //first.PullRow(i, first.exchangeCard);
                            //Refresh();
                        }
						else if (new RectangleF(screen.MapPosition.X + screen.MapPointSize * i, screen.MapPosition.Y + screen.MapPointSize * first.Mapsize, screen.MapPointSize, screen.MapPointSize).Contains(e.Location))
                        {
							push = false;
							column = i;
							timer1.Enabled = true;
							timer1.Interval = 50;
							first.files.player.Play();
                            //first.PullColumn(i, first.exchangeCard);
                            //Refresh();
                        }

                    }
                }
            }
            /*
             * Hier wird moving auf false gesetzt weil wir die Maus loslassen denke das ist vernünftig xD
             */ 
			if (e.Button == MouseButtons.Left)
			{
				moving = false;
				p.X = screen.ExchangeCard.X;
				p.Y = screen.ExchangeCard.Y;
			
			}

			mouseover = false;
			Refresh();
		}


        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Mit Doppelklick die Position der exchange Card ändern
			if (new Rectangle(p.X, p.Y, screen.MapPointSize, screen.MapPointSize).Contains(e.Location))
            {
                first.switchPosition(first.exchangeCard);
            }
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			pixeloffset += 2;
			if (pixeloffset >= screen.MapPointSize)
			{
				first.files.player.Stop();
				if (push && row!=-1)
				{
					first.PushRow(row, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
				}
				else if(push && row ==- 1)
				{
					first.PushColumn(column, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
				}
				else if (!push && row != -1)
				{
					first.PullRow(row, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
				}
				else if (!push && row ==-1)
				{
					first.PullColumn(column, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
				}
			}
			
			Refresh();
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{

			
			/*
			checkBox1.Checked = false;
			checkBox2.Checked = false;
			checkBox3.Checked = false;
			checkBox4.Checked = false;

			if (first.Board[Convert.ToInt32((e.X - first.MappositionX) / first.MapPointSize), Convert.ToInt32((e.Y - first.MappositionY) / first.MapPointSize)].top == true)
			{
				checkBox1.Checked = true;
			}
			if (first.Board[Convert.ToInt32((e.X - first.MappositionX) / first.MapPointSize), Convert.ToInt32((e.Y - first.MappositionY) / first.MapPointSize)].right == true)
			{
				checkBox2.Checked = true;
			}
			if (first.Board[Convert.ToInt32((e.X - first.MappositionX) / first.MapPointSize), Convert.ToInt32((e.Y - first.MappositionY) / first.MapPointSize)].bottom == true)
			{
				checkBox3.Checked = true;
			}
			if (first.Board[Convert.ToInt32((e.X - first.MappositionX) / first.MapPointSize), Convert.ToInt32((e.Y - first.MappositionY) / first.MapPointSize)].left == true)
			{
				checkBox4.Checked = true;
			}
			*/
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			screen = new Gamescreen(first, this);
			Refresh();
			 
		}

	




	}
}


