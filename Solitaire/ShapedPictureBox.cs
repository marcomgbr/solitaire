using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransparentControl2
{
    public class ShapedPictureBox : PictureBox
    {
        GraphicsPath path;
        bool generatePath = true;

        public ShapedPictureBox()
        {
        }

        public ShapedPictureBox(string imagePath)
        {
            Load(imagePath);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Image == null)
            {
                return;
            }

            Bitmap bmp = new Bitmap(this.Image);

            if (this.generatePath)
            {
                this.path = CreatePathFromBitmap(bmp);
                this.generatePath = false;
            }

            this.Size = bmp.Size;
            this.Region = new Region(path);

            Rectangle imageRect = new Rectangle(0, 0, this.Width, this.Height);
            e.Graphics.DrawImage(bmp, imageRect, imageRect, GraphicsUnit.Pixel);

            base.OnPaint(e);
        }

        // Generate the graphics path that represents the figure surrounded
        // by a color that represents the transparent area. This color is the
        // color of the first pixel left-top in the image.
        private static GraphicsPath CreatePathFromBitmap(Bitmap bitmap)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Color colorTransparent = bitmap.GetPixel(0, 0);

            for (int row = 0; row < bitmap.Height; row++)
            {
                // This is to store the first opaque pixel found. This value will
                // determine where we start scanning for trailing opaque pixels.
                int colOpaquePixel = 0;

                for (int col = 0; col < bitmap.Width; col++)
                {
                    // If this is an opaque pixel, mark it and search 
                    // for anymore trailing behind
                    if (bitmap.GetPixel(col, row) != colorTransparent)
                    {
                        // Opaque pixel found, mark current position
                        colOpaquePixel = col;

                        // Create another variable to set the current pixel position
                        int colNext = col;

                        // Starting from current found opaque pixel, search for 
                        // anymore opaque pixels trailing behind, until a transparent
                        // pixel is found or minimum width is reached
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                        {
                            if (bitmap.GetPixel(colNext, row) == colorTransparent) break;
                        }

                        // Form a rectangle for line of opaque pixels found and 
                        // add it to our graphics path
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row,
                            colNext - colOpaquePixel, 1));

                        // No need to scan the line of opaque pixels just found
                        col = colNext;
                    }
                }
            }

            return graphicsPath;
        }

        protected override void OnResize(EventArgs e)
        {
            this.generatePath = true;
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            this.generatePath = true;
        }

        protected override void OnLoadCompleted(AsyncCompletedEventArgs e)
        {
            this.generatePath = true;
        }

        protected override void OnMove(EventArgs e)
        {
            this.generatePath = true;
        }
    }
}




//public class ShapedPictureBox : PictureBox
//{
//    public ShapedPictureBox()
//    {
//    }

//    public ShapedPictureBox(string imagePath)
//    {
//        Load(imagePath);
//    }

//    protected override void OnPaint(PaintEventArgs e)
//    {
//        //Bitmap bmp = new Bitmap(@"c:\temp\08.png");

//        if (this.Image == null)
//        {
//            return;
//        }

//        Bitmap bmp = new Bitmap(this.Image);

//        using (GraphicsPath path = CreateGraphicsPathFromBitmap(bmp))
//        {
//            this.Size = bmp.Size;
//            this.Region = new Region(path);

//            Rectangle imageRect = new Rectangle(0, 0, this.Width, this.Height);
//            e.Graphics.DrawImage(bmp, imageRect, imageRect, GraphicsUnit.Pixel);

//            base.OnPaint(e);
//        }
//    }

//    // Calculate the graphics path that representing the figure in the bitmap 
//    // excluding the transparent color which is the top left pixel.
//    private static GraphicsPath CreateGraphicsPathFromBitmap(Bitmap bitmap)
//    {
//        // Create GraphicsPath for our bitmap calculation
//        GraphicsPath graphicsPath = new GraphicsPath();

//        // Use the top left pixel as our transparent color
//        Color colorTransparent = bitmap.GetPixel(0, 0);

//        // This is to store the column value where an opaque pixel is first found.
//        // This value will determine where we start scanning for trailing 
//        // opaque pixels.
//        int colOpaquePixel = 0;

//        // Go through all rows (Y axis)
//        for (int row = 0; row < bitmap.Height; row++)
//        {
//            // Reset value
//            colOpaquePixel = 0;

//            // Go through all columns (X axis)
//            for (int col = 0; col < bitmap.Width; col++)
//            {
//                // If this is an opaque pixel, mark it and search 
//                // for anymore trailing behind
//                if (bitmap.GetPixel(col, row) != colorTransparent)
//                {
//                    // Opaque pixel found, mark current position
//                    colOpaquePixel = col;

//                    // Create another variable to set the current pixel position
//                    int colNext = col;

//                    // Starting from current found opaque pixel, search for 
//                    // anymore opaque pixels trailing behind, until a transparent
//                    // pixel is found or minimum width is reached
//                    for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
//                        if (bitmap.GetPixel(colNext, row) == colorTransparent)
//                            break;

//                    // Form a rectangle for line of opaque pixels found and 
//                    // add it to our graphics path
//                    graphicsPath.AddRectangle(new Rectangle(colOpaquePixel,
//                                               row, colNext - colOpaquePixel, 1));

//                    // No need to scan the line of opaque pixels just found
//                    col = colNext;
//                }
//            }
//        }

//        return graphicsPath;
//    }
//}