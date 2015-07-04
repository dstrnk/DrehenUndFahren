using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;

namespace DrehenUndGehen
{
    class Renderer
    {

        /* 
         * Der Renderer wird für die Zeichnung benutzt
         * Wo wird welcher Mappoint gezeichnet und wo wird die exchangeCard plaziert.
         */ 
        public Map first{get;set;}
        Graphics g;
		public Gamescreen screen { get; set; }
		public TextureBrush brush { get; set; }
		public SolidBrush brush1  {get; set;}
		public SolidBrush brush2 { get; set; }
		private Random ran;
		


		public Renderer()
        {
            first   = new Map();          
        }
        public Renderer(Map map ,Graphics g,Gamescreen screen)
        {
            this.first = map;           
            this.g = g;
			this.screen = screen;
			this.brush = new TextureBrush(first.files.menuBrush, WrapMode.TileFlipXY);
			this.brush1= new SolidBrush(Color.PaleVioletRed);
			this.brush2 = new SolidBrush(Color.PaleGreen);
			this.ran = new Random();
			
			
        }

        public void drawPlayer()
        {
            g.DrawImage(first.player1.shownBitmap, first.player1.positionPixel.X, first.player1.positionPixel.Y, first.player1.getPlayerSize(screen), first.player1.getPlayerSize(screen));
            g.DrawImage(first.player2.shownBitmap, first.player2.positionPixel.X, first.player2.positionPixel.Y, first.player2.getPlayerSize(screen), first.player2.getPlayerSize(screen));
        }

        public void drawMap()
        {
			
			int x = screen.MapPointSize;

            for (int i = 0; i < first.Mapsize; i++)
            {
                for (int j = 0; j < first.Mapsize; j++)
                {                  
                    if(j==0 && i%2 !=0)
                    {                       
                        g.DrawImage(first.files.arrowbottom, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x- x, x, x);
						
                    }
                    else if(i==0 && j%2 != 0)
                    {
						g.DrawImage(first.files.arrowright, screen.MapPosition.X + i * x - x, screen.MapPosition.Y + j * x, x, x);
                    }
					else if (j == first.Mapsize-1 && i % 2 != 0)
                    {
						g.DrawImage(first.files.arrowtop, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x + x, x, x);
                    }
					else if (i == first.Mapsize - 1 && j % 2 != 0)
					{
						g.DrawImage(first.files.arrowleft, screen.MapPosition.X + i * x + x, screen.MapPosition.Y + j * x, x, x);
					}

					g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i, screen.MapPosition.Y + x * j, x, x);
						if (first.Board[i, j].proppic != null)
						{
							//first.Board[i, j].prop.MakeTransparent(Color.Black);
							g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4), screen.MapPosition.Y + x * j + (screen.MapPointSize / 4), x / 2, x / 2);
						}
									
                }
            }
			//g.DrawImage(first.files.exchangCardFrame, 1200, first.MappositionY, first.MapPointSize * 4, first.MapPointSize * 4);
           
            
        }
		public void drawMap(int PixelOffset ,bool push, int row=-1,int column=-1)
		{
			
			if (push && row != -1)
			{
				int x = screen.MapPointSize;

				for (int i = 0; i < first.Mapsize; i++)
				{
					for (int j = 0; j < first.Mapsize; j++)
					{

						if (j == 0 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowbottom, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x - x, x, x);
						}
						else if (i == 0 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowright, screen.MapPosition.X + i * x - x, screen.MapPosition.Y + j * x, x, x);
						}
						else if (j == first.Mapsize - 1 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowtop, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x + x, x, x);
						}
						else if (i == first.Mapsize - 1 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowleft, screen.MapPosition.X + i * x + x, screen.MapPosition.Y + j * x, x, x);
						}
						if (j != row)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i, screen.MapPosition.Y + x * j, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4), screen.MapPosition.Y + x * j + (screen.MapPointSize / 4), x / 2, x / 2);
							}
						}
						if ( j == row)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i + PixelOffset, screen.MapPosition.Y + x * j, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4) + PixelOffset, screen.MapPosition.Y + x * j + (screen.MapPointSize / 4), x / 2, x / 2);
							}
						}

					}
				}
			}
			if (push && row == -1)
			{
				int x = screen.MapPointSize;

				for (int i = 0; i < first.Mapsize; i++)
				{
					for (int j = 0; j < first.Mapsize; j++)
					{

						if (j == 0 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowbottom, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x - x, x, x);
						}
						else if (i == 0 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowright, screen.MapPosition.X + i * x - x, screen.MapPosition.Y + j * x, x, x);
						}
						else if (j == first.Mapsize - 1 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowtop, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x + x, x, x);
						}
						else if (i == first.Mapsize - 1 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowleft, screen.MapPosition.X + i * x + x, screen.MapPosition.Y + j * x, x, x);
						}
						if (i != column)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i, screen.MapPosition.Y + x * j, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4), screen.MapPosition.Y + x * j + (screen.MapPointSize / 4), x / 2, x / 2);
							}
						}
						if (i == column)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i, screen.MapPosition.Y + x * j + PixelOffset, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4), screen.MapPosition.Y + x * j + (screen.MapPointSize / 4) + PixelOffset, x / 2, x / 2);
							}
						}

					}
				}
			}
			if (!push && column != -1)
			{
				int x = screen.MapPointSize;

				for (int i = 0; i < first.Mapsize; i++)
				{
					for (int j = 0; j < first.Mapsize; j++)
					{

						if (j == 0 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowbottom, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x - x, x, x);
						}
						else if (i == 0 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowright, screen.MapPosition.X + i * x - x, screen.MapPosition.Y + j * x, x, x);
						}
						else if (j == first.Mapsize - 1 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowtop, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x + x, x, x);
						}
						else if (i == first.Mapsize - 1 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowleft, screen.MapPosition.X + i * x + x, screen.MapPosition.Y + j * x, x, x);
						}
						if (i != column)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i, screen.MapPosition.Y + x * j, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4), screen.MapPosition.Y + x * j + (screen.MapPointSize / 4), x / 2, x / 2);
							}
						}
						if (i == column)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i, screen.MapPosition.Y + x * j - PixelOffset, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4), screen.MapPosition.Y + x * j + (screen.MapPointSize / 4) - PixelOffset, x / 2, x / 2);
							}
						}

					}

				}

			}
			if (!push && column == -1)
			{
				int x = screen.MapPointSize;

				for (int i = 0; i < first.Mapsize; i++)
				{
					for (int j = 0; j < first.Mapsize; j++)
					{

						if (j == 0 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowbottom, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x - x, x, x);
						}
						else if (i == 0 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowright, screen.MapPosition.X + i * x - x, screen.MapPosition.Y + j * x, x, x);
						}
						else if (j == first.Mapsize - 1 && i % 2 != 0)
						{
							g.DrawImage(first.files.arrowtop, screen.MapPosition.X + i * x, screen.MapPosition.Y + j * x + x, x, x);
						}
						else if (i == first.Mapsize - 1 && j % 2 != 0)
						{
							g.DrawImage(first.files.arrowleft, screen.MapPosition.X + i * x + x, screen.MapPosition.Y + j * x, x, x);
						}
						if (j != row)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i, screen.MapPosition.Y + x * j, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4), screen.MapPosition.Y + x * j + (screen.MapPointSize / 4), x / 2, x / 2);
							}
						}
						if (j == row)
						{
							g.DrawImage(first.Board[i, j].looks, screen.MapPosition.X + x * i - PixelOffset, screen.MapPosition.Y + x * j, x, x);
							if (first.Board[i, j].proppic != null)
							{
								//first.Board[i, j].prop.MakeTransparent(Color.Black);
								g.DrawImage(first.Board[i, j].proppic, screen.MapPosition.X + x * i + (screen.MapPointSize / 4) - PixelOffset, screen.MapPosition.Y + x * j + (screen.MapPointSize / 4), x / 2, x / 2);
							}
						}

					}
				}
			}
		}
		public void drawExchangeCard()
		{
			
			g.DrawImage(first.exchangeCard.looks,screen.ExchangeCard.X,screen.ExchangeCard.Y,screen.MapPointSize,screen.MapPointSize);
			if (first.exchangeCard.proppic != null)
			{

				g.DrawImage(first.exchangeCard.proppic, screen.ExchangeCard.X + screen.ExchangeCard.Width / 4, screen.ExchangeCard.Y + screen.ExchangeCard.Height / 4, screen.MapPointSize / 2, screen.MapPointSize / 2);

			}
		}
		public void drawMovingExCard(int x, int y)
		{
			g.DrawImage(first.exchangeCard.looks, x, y, screen.MapPointSize, screen.MapPointSize);
			if (first.exchangeCard.proppic != null)
			{

				g.DrawImage(first.exchangeCard.proppic,x /*screen.ExchangeCard.X*/ + screen.ExchangeCard.Width / 4,y /*screen.ExchangeCard.Y*/ + screen.ExchangeCard.Height / 4, screen.MapPointSize / 2, screen.MapPointSize / 2);

			}
 
		}
		
		public void drawExchangeCard(int pixeloffset,bool push,int row = -1,int column = -1 )
		{
			if(push && row !=-1)
			{
				g.DrawImage(first.exchangeCard.looks, screen.MapPosition.X - screen.MapPointSize + pixeloffset, screen.MapPosition.Y + screen.MapPointSize * row, screen.MapPointSize, screen.MapPointSize);
				if (first.exchangeCard.proppic != null)
				{
					g.DrawImage(first.exchangeCard.proppic, screen.MapPosition.X - screen.MapPointSize + pixeloffset + screen.MapPointSize / 4, screen.MapPosition.Y + screen.MapPointSize * row + screen.MapPointSize / 4, screen.MapPointSize / 2, screen.MapPointSize / 2); 
				}
			}
			else if (push && row == -1)
			{
				g.DrawImage(first.exchangeCard.looks, screen.MapPosition.X + screen.MapPointSize * column, screen.MapPosition.Y - screen.MapPointSize + pixeloffset, screen.MapPointSize, screen.MapPointSize);
				if (first.exchangeCard.proppic!= null)
				{
					g.DrawImage(first.exchangeCard.proppic, screen.MapPosition.X + screen.MapPointSize * column + screen.MapPointSize / 4, screen.MapPosition.Y - screen.MapPointSize + pixeloffset + screen.MapPointSize / 4, screen.MapPointSize / 2, screen.MapPointSize / 2); 
				}
			}
			else if (!push && row != -1)
			{
				g.DrawImage(first.exchangeCard.looks, screen.MapPosition.X + screen.MapPointSize * first.Mapsize - pixeloffset, screen.MapPosition.Y + screen.MapPointSize * row, screen.MapPointSize, screen.MapPointSize);
				if (first.exchangeCard.proppic != null)
				{
					g.DrawImage(first.exchangeCard.proppic, screen.MapPosition.X + screen.MapPointSize * first.Mapsize - pixeloffset + screen.MapPointSize / 4, screen.MapPosition.Y + screen.MapPointSize * row + screen.MapPointSize / 4, screen.MapPointSize / 2, screen.MapPointSize / 2);
				}
			}
			else 
			{
				g.DrawImage(first.exchangeCard.looks, screen.MapPosition.X + screen.MapPointSize * column, screen.MapPosition.Y + screen.MapPointSize * first.Mapsize - pixeloffset, screen.MapPointSize, screen.MapPointSize);
				if (first.exchangeCard.proppic != null)
				{
					g.DrawImage(first.exchangeCard.proppic, screen.MapPosition.X + screen.MapPointSize * column + screen.MapPointSize / 4, screen.MapPosition.Y + screen.MapPointSize * first.Mapsize - pixeloffset + screen.MapPointSize / 4, screen.MapPointSize / 2, screen.MapPointSize / 2);
				}
			}
		}

		public void drawMarks(Point p)
		{

			int x = screen.MapPointSize;
			
			Pen penRed = new Pen(brush1,8);
			Pen penGreen = new Pen(brush2, 8);
			for (int i = 0; i < first.Mapsize; i++)
			{
				for (int j = 0; j < first.Mapsize; j++)
				{
                    if (i == 0 && j % 2 != 0 && first.player1.getMapPosition(screen) != new Point(j, first.Mapsize - 1) && first.player2.getMapPosition(screen) != new Point(j, first.Mapsize - 1) && (first.dontPush.Y != j || first.dontPush.X == first.Mapsize-1))//obere Seite
					{
                        Rectangle rec = new Rectangle(screen.MapPosition.X + j * x, screen.MapPosition.Y + i * x - x, x, x);

                        if (rec.Contains(p))
                        {
                            g.DrawRectangle(penGreen, screen.MapPosition.X + j * x, screen.MapPosition.Y + i * x - x, x, x);
                        }
                        else
                        {
                            g.DrawRectangle(penRed, screen.MapPosition.X + j * x, screen.MapPosition.Y + i * x - x, x, x);
                        }						
					}
                    if (j == 0 && i % 2 != 0 && first.player1.getMapPosition(screen) != new Point(first.Mapsize - 1, i) && first.player2.getMapPosition(screen) != new Point(first.Mapsize - 1, i) && (first.dontPush.X != i || first.dontPush.Y == first.Mapsize-1)) //linke Seite
					{
						Rectangle rec = new Rectangle(screen.MapPosition.X + j * x - x, screen.MapPosition.Y + i * x, x, x);
						if (rec.Contains(p))
						{
							g.DrawRectangle(penGreen, screen.MapPosition.X + j * x - x, screen.MapPosition.Y + i * x, x, x);
						}
						else
						{
							g.DrawRectangle(penRed, screen.MapPosition.X + j * x - x, screen.MapPosition.Y + i * x, x, x);
						}

					}
                    if (i == first.Mapsize - 1 && j % 2 != 0 && first.player1.getMapPosition(screen) != new Point(j, 0) && first.player2.getMapPosition(screen) != new Point(j, 0) && (first.dontPush.Y != j || first.dontPush.X == 0)) //untere Seite
					{
						Rectangle rec = new Rectangle(screen.MapPosition.X + j * x, screen.MapPosition.Y + i * x + x, x, x);
						if (rec.Contains(p))
						{
							g.DrawRectangle(penGreen, screen.MapPosition.X + j * x, screen.MapPosition.Y + i * x + x, x, x);
						}
						else
						{
							g.DrawRectangle(penRed, screen.MapPosition.X + j * x, screen.MapPosition.Y + i * x + x, x, x);
						}

					}
                    if (j == first.Mapsize - 1 && i % 2 != 0 && first.player1.getMapPosition(screen) != new Point(0, i) && first.player2.getMapPosition(screen) != new Point(0, i) && (first.dontPush.X != i || first.dontPush.Y == 0)) //rechte Seite
					{
						Rectangle rec = new Rectangle(screen.MapPosition.X + j * x + x, screen.MapPosition.Y + i * x, x, x);
						if (rec.Contains(p))
						{
							g.DrawRectangle(penGreen, screen.MapPosition.X + j * x + x, screen.MapPosition.Y + i * x, x, x);
						}
						else
						{
							g.DrawRectangle(penRed, screen.MapPosition.X + j * x + x, screen.MapPosition.Y + i * x, x, x);
						}
						
					}
				}
			}
		}	

	public void drawBackground(bool mouseover)
	{
		
		g.DrawImage(first.files.background4, screen.Background);
		g.FillRectangle(brush, screen.UserMenu);
		g.DrawImage(first.files.menuFrame, screen.UserMenu.X-2, screen.UserMenu.Y, screen.ScreenWidth - screen.UserMenu.X, screen.ScreenHight);
		g.DrawImage(first.files.exchangCardFrame, screen.ExchangeCardFrame);
		g.DrawImage(first.files.exchangCardFrame, screen.propToFindFrame);
		//g.DrawImage(first.files.Buttonsettings, screen.propToFindFrame.X, screen.propToFindFrame.Y + screen.MapPointSize, screen.MapPointSize, screen.MapPointSize);
		if (mouseover == true)
		{
			g.DrawImage(first.files.button2, screen.Button);
		}
		else 
		g.DrawImage(first.files.button, screen.Button);
		//g.DrawImage(first.files.menuBackground, screen.UserMenuPosition.X,screen.UserMenuPosition.Y,screen.MaximizedScreenWidth-screen.UserMenuPosition.X,screen.MaximizedScreenHight);
	}

	public void drawPropToFind()
	{
        g.DrawImage(first.searchProppic, screen.propToFind);
       /* string[] keys = first.usedProps.Keys.ToArray();
        int savecount = 0;
    
        {
            int count = ran.Next(first.usedProps.Count);
            savecount = count;

            if (first.usedProps.Count != 0)
            {
                
                g.DrawImage(first.searchProppic, screen.propToFind);


            }
        }
       /* else
        {
            g.DrawImage(first.usedProps[keys[savecount]], screen.propToFind);
            
        }
			*/
		

	}



    }
}
