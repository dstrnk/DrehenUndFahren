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
		bool moving, push, mouseover;
		
        bool pathMoving; //gibt an ob grad geschoben wird
       

		Point p;
		int row = -1; 
		int column = -1;
		int pixeloffset = 0;
		Gamescreen screen;

        int pixelCounter;
        Point direction;
        int commandListPos = 0;
        int clickx;
        int clicky;
        int commandCount;
        int timerCounter;
        List<String> commandList;

        Player activePlayer;

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

            pathMoving = false;
            
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            first.player1.setPositionPixel(screen);
            first.player1.playerId = 1;
            first.player2.setPositionPixel(screen);
            first.player2.playerId = 2;

            int startplayer = 1;
            if (startplayer == 1)
            {
                label1.Text = "Spieler 1 schiebt";
                first.player1.pushAviable = true;
                activePlayer = first.player1;

            }
            else
            {
                label1.Text = "Spieler 2 schiebt";
                first.player2.pushAviable = true;
                activePlayer = first.player2;
            }
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
            if (!activePlayer.playerMoving && activePlayer.pushAviable)
            {
                if (screen.Button.Contains(e.Location))
                {
                    first.switchPosition(first.exchangeCard);
                    mouseover = true;
                    Invalidate(screen.Button);
                }

                if (e.Button == MouseButtons.Left && screen.ExchangeCard.Contains(e.Location))         // Überprüfung ob sich die Maus auf der exchangeCard Befindet
                {
                    p.X = e.X - screen.MapPointSize / 2;                                                                                         // Falls ja wird die Maus in die Mitte der exchangeCard gesetzt
                    p.Y = e.Y - screen.MapPointSize / 2;                                                                                     // und moving wird auf true gesetzt
                    moving = true;
                }
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
		{
            if (!activePlayer.playerMoving && !pathMoving)
            {
                /*
                 * Hier wird überprüft ob die exchangeCard auf der richtigen Position abgelegt wurde(Rote Pfeile)
                 * falls ja wird die Reihe/Spalte entsprechend verschoben
                 */
                if (moving)
                {
                    for (int i = 0; i < first.Mapsize; i++)
                    {
                        if (i % 2 != 0 && activePlayer.pushAviable)
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
                                nextStepPlayer();
                                pathMoving = true;

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
                                nextStepPlayer();
                                pathMoving = true;
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
                                nextStepPlayer();
                                pathMoving = true;
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
                                nextStepPlayer();
                                pathMoving = true;
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
		}

        private void nextStepPlayer() 
        {
            activePlayer.moveAviable = true;
            activePlayer.pushAviable = false;

            if (activePlayer.playerId == 1)
            {
                label1.Text = "Spieler 1 geht";
            }
            else
            {
                label1.Text = "Spieler 2 geht";
            }
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
                    pathMoving = false;
				}
				else if(push && row ==- 1)
				{
					first.PushColumn(column, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
                    pathMoving = false;
				}
				else if (!push && row != -1)
				{
					first.PullRow(row, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
                    pathMoving = false;
				}
				else if (!push && row ==-1)
				{
					first.PullColumn(column, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
                    pathMoving = false;
				}
			}
			
			Refresh();
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
            clickx = Convert.ToInt32((e.X - screen.MapPosition.X) / screen.MapPointSize);
            clicky = Convert.ToInt32((e.Y - screen.MapPosition.Y) / screen.MapPointSize);
            if (!pathMoving && !activePlayer.playerMoving && activePlayer.moveAviable && first.findPath(activePlayer.getMapPosition(screen), new Point(clickx, clicky)).First() != "NO WAY!")
            {
                activePlayer.moveAviable = false;
                activePlayer.playerMoving = true;

                commandList = first.findPath(activePlayer.getMapPosition(screen), new Point(clickx, clicky));
                commandCount = commandList.Count;
                
                commandListPos = 0;
                useCommand(0);
            }
		}

        private void useCommand(int i)
        {
            pixelCounter = screen.MapPointSize;
            if (commandList.Any())
            {
                if (commandList[i] == "up")
                {
                    direction = new Point(0, -1);
                    activePlayer.usedAnimation = activePlayer.getAnimation("up");
                    playerTimer.Enabled = true;

                }
                else if (commandList[i] == "down")
                {
                    direction = new Point(0, 1);
                    activePlayer.usedAnimation = activePlayer.getAnimation("down");
                    playerTimer.Enabled = true;
                }
                else if (commandList[i] == "left")
                {
                    direction = new Point(-1, 0);
                    activePlayer.usedAnimation = activePlayer.getAnimation("left");
                    playerTimer.Enabled = true;
                }
                else if (commandList[i] == "right")
                {
                    direction = new Point(1, 0);
                    activePlayer.usedAnimation = activePlayer.getAnimation("right");
                    playerTimer.Enabled = true;
                }
                else
                {

                }
            }

        }

		private void Form1_Resize(object sender, EventArgs e)
		{
			screen = new Gamescreen(first, this);
            first.player1.setPositionPixel(screen);
            first.player2.setPositionPixel(screen);
            Refresh();
		}

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            timerCounter++;
            
            if (Math.Abs(activePlayer.counterX) == pixelCounter || Math.Abs(activePlayer.counterY) == pixelCounter)
            {
                playerTimer.Enabled = false;
                activePlayer.counterX = 0;
                activePlayer.counterY = 0;        
                //playerTimer.Stop();
                commandListPos ++;
                if (commandListPos < commandCount)
                    useCommand(commandListPos);

                else if (commandListPos == commandCount)
                {
                    //activePlayer.getMapPosition(screen);  Roman muss das da hin_? ich seh da keinen Sinn-??!?
                    Point p = activePlayer.getMapPosition(screen);
                    activePlayer.playerMoving = false;  //hört auf zu Laufen
                    if(first.Board[p.X,p.Y].propname == first.searchProp)
                    { 
                        MessageBox.Show("Du arsch hast es gefunden");

                        first.usedProps.Remove(first.Board[p.X, p.Y].propname);
                        first.Board[p.X, p.Y].proppic = null;
                        first.Board[p.X, p.Y].propname = null;
                        if (first.usedProps.Count != 0)
                        {
                            first.setNewRandomProp();
                        }
                        else
                        {
                            MessageBox.Show("Das Spiel ist vorbei du Arsch");
                        }
                        Refresh();
                    
                    }
                    if (activePlayer.playerId == 1)
                    {
                        activePlayer = first.player2;
                        label1.Text = "Spieler 2 schiebt";
                    }
                    else
                    {
                        activePlayer = first.player1;
                        label1.Text = "Spieler 1 schiebt";
                    }

                    activePlayer.pushAviable = true;                
                }           
            }
            else
            {
                activePlayer.counterX += direction.X;
                activePlayer.counterY += direction.Y;

                activePlayer.setPositionPixel(activePlayer.positionPixel.X + direction.X, activePlayer.positionPixel.Y + direction.Y);

                int times = timerCounter / 50;
                int nr = timerCounter - times * 50;

                activePlayer.shownBitmap = activePlayer.usedAnimation[Convert.ToInt32(nr / 25)];

                Invalidate(new Rectangle(activePlayer.positionPixel.X + direction.X, activePlayer.positionPixel.Y, screen.MapPointSize, screen.MapPointSize));  
            }
            
        }
	}
}


