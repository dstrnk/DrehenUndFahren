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

        int oldP1PosX;
        int oldP1PosY;
        int oldP2PosX;
        int oldP2PosY;

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
            label1.Visible = false;
            int startplayer = 1;
            if (startplayer == 1)
            {
                label1.Text = "P1 schiebt";
                first.player1.pushAviable = true;
                activePlayer = first.player1;

            }
            else
            {
                label1.Text = "P2 schiebt";
                first.player2.pushAviable = true;
                activePlayer = first.player2;
            }
		}

		public void Form1_Paint(object sender, PaintEventArgs e)
		{

			g = e.Graphics;
			
			
			
			rend = new Renderer(first, g,screen,label1);
			rend.drawBackground(mouseover);
            rend.drawPoints();
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


                //Spieler1 verschieben
                if (first.player1.getMapPosition(screen).Y == row && push)
                    first.player1.positionPixel = new Point(oldP1PosX + pixeloffset, oldP1PosY);
                else if (first.player1.getMapPosition(screen).Y == row && !push)
                    first.player1.positionPixel = new Point(oldP1PosX - pixeloffset, oldP1PosY);
                else if (first.player1.getMapPosition(screen).X == column && push)
                    first.player1.positionPixel = new Point(oldP1PosX, oldP1PosY + pixeloffset);
                else if (first.player1.getMapPosition(screen).X == column && !push)
                    first.player1.positionPixel = new Point(oldP1PosX, oldP1PosY - pixeloffset);

                //Spieler2 verschieben
                if (first.player2.getMapPosition(screen).Y == row && push)
                    first.player2.positionPixel = new Point(oldP2PosX + pixeloffset, oldP2PosY);
                else if (first.player2.getMapPosition(screen).Y == row && !push)
                    first.player2.positionPixel = new Point(oldP2PosX - pixeloffset, oldP2PosY);
                else if (first.player2.getMapPosition(screen).X == column && push)
                    first.player2.positionPixel = new Point(oldP2PosX, oldP2PosY + pixeloffset);
                else if (first.player2.getMapPosition(screen).X == column && !push)
                    first.player2.positionPixel = new Point(oldP2PosX, oldP2PosY - pixeloffset);
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
                            oldP1PosX = first.player1.positionPixel.X;
                            oldP1PosY = first.player1.positionPixel.Y;
                            oldP2PosX = first.player2.positionPixel.X;
                            oldP2PosY = first.player2.positionPixel.Y;

                            if (new RectangleF(screen.MapPosition.X - screen.MapPointSize, screen.MapPosition.Y + screen.MapPointSize * i, screen.MapPointSize, screen.MapPointSize).Contains(e.Location) && first.player1.getMapPosition(screen) != new Point(first.Mapsize - 1, i) && first.player2.getMapPosition(screen) != new Point(first.Mapsize - 1, i) && (first.dontPush.X != i || first.dontPush.Y == first.Mapsize-1))
                            {
                                push = true;
                                row = i;
                                timer1.Enabled = true;
                                timer1.Interval = 50;
                                first.files.player.Play();
                                //timer1.Start();
                                //first.PushRow(i, first.exchangeCard);
                                first.dontPush = new Point(i, first.Mapsize-1);
                                pathMoving = true;

                            }
                            else if (new RectangleF(screen.MapPosition.X + screen.MapPointSize * i, screen.MapPosition.Y - screen.MapPointSize, screen.MapPointSize, screen.MapPointSize).Contains(e.Location) && first.player1.getMapPosition(screen) != new Point(i, first.Mapsize - 1) && first.player2.getMapPosition(screen) != new Point(i, first.Mapsize - 1) && (first.dontPush.Y != i || first.dontPush.X == first.Mapsize - 1))
                            {
                                push = true;
                                column = i;
                                timer1.Enabled = true;
                                timer1.Interval = 50;
                                first.files.player.Play();

                                //first.PushColumn(i, first.exchangeCard);
                                //Refresh();
                                first.dontPush = new Point(first.Mapsize-1, i);
                                pathMoving = true;
                            }
                            else if (new RectangleF(screen.MapPosition.X + screen.MapPointSize * first.Mapsize, screen.MapPosition.Y + screen.MapPointSize * i, screen.MapPointSize, screen.MapPointSize).Contains(e.Location) && first.player1.getMapPosition(screen) != new Point(0, i) && first.player2.getMapPosition(screen) != new Point(0, i) && (first.dontPush.X != i || first.dontPush.Y == 0))
                            {
                                push = false;
                                row = i;
                                timer1.Enabled = true;
                                timer1.Interval = 50;
                                first.files.player.Play();
                                //first.PullRow(i, first.exchangeCard);
                                //Refresh();
                                first.dontPush = new Point(i, 0);
                                pathMoving = true;
                            }
                            else if (new RectangleF(screen.MapPosition.X + screen.MapPointSize * i, screen.MapPosition.Y + screen.MapPointSize * first.Mapsize, screen.MapPointSize, screen.MapPointSize).Contains(e.Location) && first.player1.getMapPosition(screen) != new Point(i, 0) && first.player2.getMapPosition(screen) != new Point(i, 0) && (first.dontPush.Y != i || first.dontPush.X == 0))
                            {
                                push = false;
                                column = i;
                                timer1.Enabled = true;
                                timer1.Interval = 50;
                                first.files.player.Play();
                                first.dontPush = new Point(0, i);
                                //first.PullColumn(i, first.exchangeCard);
                                //Refresh();
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
            if (first.getConnectedPaths(activePlayer.getMapPosition(screen)).Count == 1)
            {
                activePlayer.pushAviable = false;
                if (activePlayer.playerId == 1)
                {
                    activePlayer = first.player2;
                }
                else
                {
                    activePlayer = first.player1;
                }
                activePlayer.moveAviable = false;
                activePlayer.pushAviable = true;
                if (activePlayer.playerId == 1)
                {
                    label1.Text = "P1 schiebt";
                }
                else
                {
                    label1.Text = "P2 schiebt";
                }
            }
            else
            {
                activePlayer.moveAviable = true;
                activePlayer.pushAviable = false;
                if (activePlayer.playerId == 1)
                {
                    label1.Text = "P1 geht";
                }
                else
                {
                    label1.Text = "P2 geht";
                }
            }
   
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          /* // Mit Doppelklick die Position der exchange Card ändern
			if (new Rectangle(p.X, p.Y, screen.MapPointSize, screen.MapPointSize).Contains(e.Location))
            {
                first.switchPosition(first.exchangeCard);
            }
           */
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
                    nextStepPlayer();
				}
				else if(push && row ==- 1)
				{
					first.PushColumn(column, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
                    pathMoving = false;
                    nextStepPlayer();
				}
				else if (!push && row != -1)
				{
					first.PullRow(row, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
                    pathMoving = false;
                    nextStepPlayer();
				}
				else if (!push && row ==-1)
				{
					first.PullColumn(column, first.exchangeCard);
					row = -1;
					column = -1;
					timer1.Stop();
					pixeloffset = 0;
                    pathMoving = false;
                    nextStepPlayer();
				}
			}
			
			Refresh();
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
            clickx = Convert.ToInt32((e.X - screen.MapPosition.X) / screen.MapPointSize);
            clicky = Convert.ToInt32((e.Y - screen.MapPosition.Y) / screen.MapPointSize);
            if (!pathMoving && !activePlayer.playerMoving && activePlayer.moveAviable && activePlayer.getMapPosition(screen) != new Point(clickx, clicky) && first.findPath(activePlayer.getMapPosition(screen), new Point(clickx, clicky)).First() != "NO WAY!")
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
                ;
                activePlayer.counterX = 0;
                activePlayer.counterY = 0;        
                //playerTimer.Stop();
                commandListPos ++;
                if (commandListPos < commandCount)
                    useCommand(commandListPos);

                else if (commandListPos == commandCount)
                {
                    foundProp(activePlayer.getMapPosition(screen));
                    if (activePlayer.playerId == 1)
                    {
                        activePlayer = first.player2;
                        label1.Text = "P2 schiebt";
                        
                    }
                    else
                    {
                        activePlayer = first.player1;
                        label1.Text = "P1 schiebt";
                        
                    }
                    foundProp(activePlayer.getMapPosition(screen));
                    activePlayer.pushAviable = true;                
                }
                Invalidate(new Rectangle(screen.Playeraction.X, screen.Playeraction.Y, 500, 200));
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

        private void foundProp(Point p)
        {
            activePlayer.playerMoving = false;  //hört auf zu Laufen
            if (first.Board[p.X, p.Y].propname == first.searchProp)
            {
                activePlayer.collectedItems++;  //eingesammelter Gegenstand wird dem Spieler gutgeschrieben
               


                first.usedProps.Remove(first.Board[p.X, p.Y].propname);
                first.Board[p.X, p.Y].proppic = null;
                first.Board[p.X, p.Y].propname = null;
                if (first.usedProps.Count != 0)
                {
                    first.setNewRandomProp();
                }
                else
                {
                    if (first.player1.collectedItems > first.player2.collectedItems)
                        MessageBox.Show("Spieler1 hat gewonnen!");
                    else if (first.player1.collectedItems < first.player2.collectedItems)
                        MessageBox.Show("Spieler2 hat gewonnen!");
                    else
                        MessageBox.Show("Unentschieden");
                }
                Refresh();
            }
        }
	}
}


