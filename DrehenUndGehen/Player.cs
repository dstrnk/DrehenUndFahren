using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DrehenUndGehen
{
    public class Player
    {
        public Point position { get; set; }

        private Bitmap[] down, up, right, left;

        public Player(int id, Point startPosition)
        {
            position = startPosition;
            Bitmap bild = new Bitmap("char.png");
            bild.MakeTransparent(Color.FromArgb(120, 195, 128));

            down = new Bitmap[4];
            up = new Bitmap[4];
            left = new Bitmap[4];
            right = new Bitmap[4];

            for (int i = 0; i < 3; i++)
            {
                down[i] = bild.Clone(new Rectangle(id * 96 + i * 32, 0, 32, 32), System.Drawing.Imaging.PixelFormat.DontCare);
                left[i] = bild.Clone(new Rectangle(id * 96 + i * 32, 32, 32, 32), System.Drawing.Imaging.PixelFormat.DontCare);
                right[i] = bild.Clone(new Rectangle(id * 96 + i * 32, 64, 32, 32), System.Drawing.Imaging.PixelFormat.DontCare);
                up[i] = bild.Clone(new Rectangle(id * 96 + i * 32, 96, 32, 32), System.Drawing.Imaging.PixelFormat.DontCare);

            }
            down[3] = down[1];
            up[3] = up[1];
            left[3] = left[1];
            right[3] = right[1];
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
            return down[1];
        }

    }
}
