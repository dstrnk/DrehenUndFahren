using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrehenUndGehen
{
	public class Gamescreen
	{
		public Map first;
		
		public int ScreenHight;
		public int ScreenWidth;
		
		public Rectangle MapPosition;
		public Rectangle ExchangeCard;
		public Rectangle ExchangeCardFrame;
		public Rectangle UserMenu;
		public Rectangle propToFind;
		public Rectangle propToFindFrame;
		public Rectangle Background;
		public Rectangle Button;
		public int MapPointSize { get; set; }
		

		public Gamescreen()
		{
			Size s = SystemInformation.PrimaryMonitorMaximizedWindowSize;
			ScreenHight = s.Height;
			ScreenWidth = s.Width;
						
		}
		public Gamescreen(Map first,Form form1)
		{
			this.first = first;
			//Size s = SystemInformation.w; ;
			
			ScreenHight = form1.ClientSize.Height;
			ScreenWidth = form1.ClientSize.Width;

			UserMenu = new Rectangle(ScreenWidth - ScreenWidth / 4, 0, ScreenWidth - (ScreenWidth - ScreenWidth / 4), ScreenHight);
			//UserMenuSize = new Point(s.Height, s.Width);
			
			 //= new Point(UserMenu.X + s.Width - UserMenu.X / 2 - first.SizeExchangeCard / 2, MapPosition.Y);

			Background = new Rectangle(0, 0, ScreenWidth - (ScreenWidth - UserMenu.X), ScreenHight);
			if (ScreenHight > UserMenu.X)
			{
				MapPointSize = Convert.ToInt32(UserMenu.X * 0.5 / first.Mapsize);
			}
			else
			{
				MapPointSize = Convert.ToInt32(ScreenHight * 0.5 / first.Mapsize);
			}
			MapPosition = new Rectangle(Convert.ToInt32(UserMenu.X * 0.5)-(Convert.ToInt32(first.Mapsize*MapPointSize*0.5)), (ScreenHight - first.Mapsize * MapPointSize /*first.MapPointSize*/) / 2, first.Mapsize * MapPointSize/* first.MapPointSize*/, first.Mapsize * MapPointSize);
			ExchangeCard = new Rectangle(UserMenu.X + ((ScreenWidth - UserMenu.X) / 2) - MapPointSize / 2, MapPosition.Y, MapPointSize, MapPointSize);
			Button = new Rectangle(ExchangeCard.X, ExchangeCard.Y + Convert.ToInt32(MapPointSize*1.5), MapPointSize, MapPointSize);
			ExchangeCardFrame = new Rectangle(UserMenu.X + ((ScreenWidth - UserMenu.X) / 2) - MapPointSize,ExchangeCard.Y - MapPointSize / 2, MapPointSize * 2, MapPointSize * 2);
			propToFind = new Rectangle(UserMenu.X + ((ScreenWidth - UserMenu.X) / 2) - MapPointSize / 2, ScreenHight / 2, MapPointSize, MapPointSize);
			propToFindFrame = new Rectangle(propToFind.X -(MapPointSize/2), propToFind.Y - (MapPointSize/2), MapPointSize* 2, MapPointSize * 2);



		}




	}
}
