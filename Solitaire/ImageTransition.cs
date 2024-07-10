using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitaire
{
    class ImageTransition
    {
        readonly PictureBox img;
        Point dest;
        int increment;

        public ImageTransition(PictureBox image, Point destination, int increment = 20)
        {
            this.increment = increment;
            this.img = image;
            this.dest = destination;
        }

        public void GoToDestination()
        {
            bool xEndReached = false;
            bool yEndReached = false;
            while(!xEndReached || !yEndReached)
            {
                if(!xEndReached)
                {
                    if (img.Left < dest.X)
                        img.Left += increment;
                    else
                        img.Left -= increment;

                    if (Math.Abs(dest.X - img.Left) <= increment) xEndReached = true;
                }

                if (!yEndReached)
                {
                    if (img.Top < dest.Y)
                        img.Top += increment;
                    else
                        img.Top -= increment;

                    if (Math.Abs(dest.Y - img.Top) <= increment) yEndReached = true;
                }
                
                img.BringToFront();
                Thread.Sleep(10);
            }
            Application.DoEvents();
        }
    }
}
