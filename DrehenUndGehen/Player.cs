using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DrehenUndGehen
{
    public class Player
    {
        public int playerId { get; set; }
        
        public Point positionPixel { get; set; }    //in Pixel
        public Point positionMap { get; set; }      //Mapposition

        private Bitmap[] down, up, right, left;     //alle Bilder
        public Bitmap frontBitmap { get; set; }     //Vorderansicht vom Charakter
        public Bitmap shownBitmap { get; set; }     //derzeitig geladenen Bitmap
        public Bitmap[] usedAnimation { get; set; } //Array für die Richtung in die der Charakter läuft

        public int counterX { get; set; }   //Zähler wieviele Pixel der Spieler schon gelaufen ist
        public int counterY { get; set; }

        public bool pushAviable { get; set; }   //darf der Spieler schieben?
        public bool moveAviable { get; set; }   //darf dre Spieler gehen?
        public bool playerMoving { get; set; }  //Bewegt sich der Spieler?


        public Player(int id, Point startPosition)
        {
            int playerSizePng = 32;

            playerMoving = false;
            pushAviable = false;
            moveAviable = false;

            positionMap = startPosition;

            Bitmap bild = new Bitmap("char.png");
            bild.MakeTransparent(Color.FromArgb(120, 195, 128));

            down = new Bitmap[3];
            up = new Bitmap[3];
            left = new Bitmap[3];
            right = new Bitmap[3];

            if (id < 6) //da nur 6 Charaktere auf dem Png verfügbar sind
            {
                int row = id / 4;
                int column = id % 4;
                for (int i = 0; i < 3; i++)
                {
                    down[i] = bild.Clone(new Rectangle(column * playerSizePng * 3 + i * playerSizePng, row * playerSizePng * 4, playerSizePng, playerSizePng), System.Drawing.Imaging.PixelFormat.DontCare);
                    left[i] = bild.Clone(new Rectangle(column * playerSizePng * 3 + i * playerSizePng, row * playerSizePng * 4 + playerSizePng, playerSizePng, playerSizePng), System.Drawing.Imaging.PixelFormat.DontCare);
                    right[i] = bild.Clone(new Rectangle(column * playerSizePng * 3 + i * playerSizePng, row * playerSizePng * 4 + playerSizePng * 2, playerSizePng, playerSizePng), System.Drawing.Imaging.PixelFormat.DontCare);
                    up[i] = bild.Clone(new Rectangle(column * playerSizePng * 3 + i * playerSizePng, row * playerSizePng * 4 + playerSizePng * 3, playerSizePng, playerSizePng), System.Drawing.Imaging.PixelFormat.DontCare);

                }
                frontBitmap = down[1];
                shownBitmap = frontBitmap;
                down = new Bitmap[] { down[0], down[2]};
                left = new Bitmap[] { left[0], left[2] };
                right = new Bitmap[] { right[0], right[2] };
                up = new Bitmap[] { up[0], up[2] };
            }
        }

        public void setPositionPixel(Gamescreen screen)
        {
            int xPosMap = (positionMap.X * screen.MapPointSize) + screen.MapPosition.X + (screen.MapPointSize / 2) - (this.getPlayerSize(screen) / 2);
            int yPosMap = (positionMap.Y * screen.MapPointSize) + screen.MapPosition.Y + (screen.MapPointSize / 2) - (this.getPlayerSize(screen) / 2 + this.getPlayerSize(screen) / 4);
            positionPixel = new Point(xPosMap, yPosMap);
        }

        public void setPositionPixel(int x, int y)
        {
            positionPixel = new Point(x, y);
        }

        public Point getMapPosition(Gamescreen screen) //Geht vom Spielfeld aus .X=0 und .Y=0 oberstes linkes Feld
        {
            int x = (positionPixel.X - screen.MapPosition.X) / screen.MapPointSize;
            int y = (positionPixel.Y - screen.MapPosition.Y) / screen.MapPointSize;

            positionMap = new Point(x, y);
            return positionMap;
        }

        public Bitmap[] getAnimation(String command)
        {
            if (command == "up")
                return up;
            else if (command == "down")
                return down;
            else if (command == "left")
                return left;
            else 
                return right;
        }

        public Bitmap getFrontBitmap()
        {
            return frontBitmap;
        }

        public int getPlayerSize(Gamescreen screen)
        {
            return screen.MapPointSize / 2;
        }
    }
}
