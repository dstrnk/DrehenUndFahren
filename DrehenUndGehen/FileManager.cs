using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Media;

namespace DrehenUndGehen
{
	public class FileManager
	{
		/*
		 * 
		 * 
		 * Hier werden Alle Bitmaps geladen
		 * und falls nötig ein zufälliger ausgewählt
		 */
		public Bitmap topright { get; set; }
		public Bitmap rightbottom { get; set; }
		public Bitmap bottomleft { get; set; }
		public Bitmap lefttop { get; set; }
		public Bitmap leftright { get; set; }
		public Bitmap topbottom { get; set; }
		public Bitmap lefttopright { get; set; }
		public Bitmap toprightbottom { get; set; }
		public Bitmap rightbottomleft { get; set; }
		public Bitmap bottomlefttop { get; set; }


		public Bitmap arrowbottom { get; set; }
		public Bitmap arrowtop { get; set; }
		public Bitmap arrowright { get; set; }
		public Bitmap arrowleft { get; set; }
		public Bitmap exchangCardFrame { get; set; }

		public Bitmap background1 { get; set; }
		public Bitmap background2 { get; set; }
		public Bitmap background3 { get; set; }
		public Bitmap background4 { get; set; }
		public Bitmap background5 { get; set; }

		public Bitmap button { get; set; }
		public Bitmap button2 { get; set; }

		public Bitmap menuBackground { get; set; }
		public Bitmap menuBrush { get; set; }
		public Bitmap menuFrame { get; set; }

		public SoundPlayer player { get; set; }




		

		public Bitmap Axt { get; set; }
	
		public Bitmap Schild { get; set; }
		public Bitmap Rolle { get; set; }
		public Bitmap Vase { get; set; }
		public Bitmap Krone { get; set; }
		public Bitmap Zauberstab { get; set; }
		public Bitmap Kette { get; set; }
		public Bitmap Schwert { get; set; }
		public Bitmap Ohrringe { get; set; }
		public Bitmap Murmeln { get; set; }
		public Bitmap Rucksack { get; set; }
		public Bitmap Totenschaedel { get; set; }
		public Bitmap Flacon { get; set; }
		public Bitmap Kristall { get; set; }
		public Bitmap Kelch { get; set; }
		public Bitmap Sichel { get; set; }
		public Bitmap Fass { get; set; }
		public Bitmap Kristallkugel { get; set; }
		public Bitmap Runen { get; set; }
		public Bitmap Gebeine { get; set; }
		public Bitmap Brot { get; set; }
		public Bitmap Ring { get; set; }
		public Bitmap Pfeilbogen { get; set; }
		public Bitmap Ei { get; set; }
		public Bitmap Holygranade { get; set; }
		public Bitmap Zepter { get; set; }
		public Bitmap Hook{ get; set; }
		public Bitmap Diamant { get; set; }
		public Bitmap Geld{ get; set; }
		public Bitmap Handschuhe { get; set; }
		public Bitmap Buttonsettings { get; set; }

		private Random ran;
		public List<Bitmap> Proplist { get; set; }

		public FileManager()
		{
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			player = new SoundPlayer(path + @"\stonegrind.wav");
			background1 = new Bitmap(path + @"\Background1.bmp");
			background2 = new Bitmap(path + @"\background2.bmp");
			background3 = new Bitmap(path + @"\background3.bmp");
			background4 = new Bitmap(path + @"\background4.bmp");
			background5 = new Bitmap(path + @"\background5.bmp");

			menuBrush = new Bitmap(path + @"\stonebrush.bmp");
			menuFrame = new Bitmap(path + @"\menuframe.png");

			topright = new Bitmap(path + "\\topright.png");
			rightbottom = new Bitmap(path + "\\rightbottom.png");
			bottomleft = new Bitmap(path + "\\leftbottom.png");
			lefttop = new Bitmap(path + "\\lefttop.png");
			leftright = new Bitmap(path + "\\leftright.png");
			topbottom = new Bitmap(path + "\\topbottom.png");
			lefttopright = new Bitmap(path + "\\lefttopright.png");
			toprightbottom = new Bitmap(path + "\\toprightbottom.png");
			rightbottomleft = new Bitmap(path + "\\rightbottomleft.png");
			bottomlefttop = new Bitmap(path + "\\bottomlefttop.png");

			arrowleft = new Bitmap(path + "\\arrowleft.png");
			arrowright = new Bitmap(path + "\\arrowright.png");
			arrowtop = new Bitmap(path + "\\arrowtop.png");
			arrowbottom = new Bitmap(path + "\\arrowbottom.png");


			exchangCardFrame = new Bitmap(path + "\\exchangecardframe.png");
			button = new Bitmap(path + @"\button.png");
			button2 = new Bitmap(path + @"\button2.png");
			Buttonsettings = new Bitmap(path + @"\buttonsettings1.png");




			

			Axt = new Bitmap(path + "\\items\\axt.png");
			
			Rolle = new Bitmap(path + "\\items\\Rolle.png");
			Schild = new Bitmap(path + "\\items\\Schild.png");
			Vase = new Bitmap(path + "\\items\\Vase.png");
			Krone = new Bitmap(path + "\\items\\Krone.png");
			Zauberstab = new Bitmap(path + "\\items\\Zauberstab.png");
			Rolle = new Bitmap(path + "\\items\\Rolle.png");
			Handschuhe = new Bitmap(path + "\\items\\Handschuhe.png");
			Kette = new Bitmap(path + "\\items\\Kette.png");
			Schwert = new Bitmap(path + "\\items\\Schwert.png");
			Ohrringe = new Bitmap(path + "\\items\\Ohrringe.png");
			Murmeln = new Bitmap(path + "\\items\\Murmeln.png");
			Rucksack = new Bitmap(path + "\\items\\Rucksack.png");
			Totenschaedel = new Bitmap(path + "\\items\\Totenschaedel.png");
			Flacon = new Bitmap(path + "\\items\\Flacon.png");
			Kristall = new Bitmap(path + "\\items\\Kristall.png");
			Kelch = new Bitmap(path + "\\items\\kelch.png");
			Sichel = new Bitmap(path + "\\items\\Sichel.png");
			Fass = new Bitmap(path + "\\items\\Fass.png");
			Kristallkugel = new Bitmap(path + "\\items\\Kristallkugel.png");
			Runen = new Bitmap(path + "\\items\\Runen.png");
			Gebeine = new Bitmap(path + "\\items\\Gebeine.png");
			Brot = new Bitmap(path + "\\items\\Brot.png");
			Ring = new Bitmap(path + "\\items\\Ring.png");
			Pfeilbogen = new Bitmap(path + "\\items\\Pfeilbogen.png");
			Ei = new Bitmap(path + "\\items\\Ei.png");
			Holygranade = new Bitmap(path + "\\items\\Holygranade.png");
			Zepter = new Bitmap(path + "\\items\\Zepter.png");
			Hook = new Bitmap(path + "\\items\\Hook.png");
			Diamant = new Bitmap(path + "\\items\\Diamant.png");
			Geld = new Bitmap(path + "\\items\\Geld.png");








			Proplist = new List<Bitmap>();
			ran = new Random((int)DateTime.Now.Ticks); //r
			this.fillProplist();
		}
		public Bitmap randomBitmap()
		{
			int i = ran.Next(1, 11);

			switch (i)
			{
				case 1:
					return topright;
				case 2:
					return rightbottom;
				case 3:
					return bottomleft;
				case 4:
					return lefttop;
				case 5:
					return leftright;
				case 6:
					return topbottom;
				case 7:
					return lefttopright;
				case 8:
					return toprightbottom;
				case 9:
					return rightbottomleft;
				case 10:
					return bottomlefttop;

				default:
					return null;
			}

		}
		public void fillProplist()
		{			
			Proplist.Add(Axt);
			Proplist.Add(Schild);
			Proplist.Add(Rolle);
			Proplist.Add(Vase);
			Proplist.Add(Krone);
			Proplist.Add(Zauberstab);
			Proplist.Add(Kette);
			Proplist.Add(Schwert);
			Proplist.Add(Ohrringe);
			Proplist.Add(Murmeln);
			Proplist.Add(Rucksack);
			Proplist.Add(Totenschaedel);
			Proplist.Add(Flacon);
			Proplist.Add(Kristall);
			Proplist.Add(Kelch);
			Proplist.Add(Sichel);
			Proplist.Add(Fass);
			Proplist.Add(Kristallkugel);
			Proplist.Add(Runen);
			Proplist.Add(Gebeine);
			Proplist.Add(Brot);
			Proplist.Add(Ring);
			Proplist.Add(Pfeilbogen);
			Proplist.Add(Ei);
			Proplist.Add(Holygranade);
			Proplist.Add(Zepter);
			Proplist.Add(Hook);
			Proplist.Add(Diamant);
			Proplist.Add(Geld);
		}

	}
}
