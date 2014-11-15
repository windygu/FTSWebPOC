using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FTS.BaseUI.Controls
{
    public class BitmapRegion
    {
        public BitmapRegion()
        { }
        public static void CreateControlRegion(Control control, Bitmap bitmap,bool header)
        {            
            if (control == null || bitmap == null)
                return;            
            control.Width = bitmap.Width;
            control.Height = bitmap.Height;
            if (control is System.Windows.Forms.Panel)
            {
                Panel panel = (Panel)control;                              
                panel.BackgroundImage = bitmap;                
                GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap,header);
                panel.Region = new Region(graphicsPath);
            }
        }
        private static GraphicsPath CalculateControlGraphicsPath(Bitmap bitmap,bool header)
        {            
            GraphicsPath graphicsPath = new GraphicsPath();
            Color colorTransparent = bitmap.GetPixel(0, 0);
            if (!header)
                colorTransparent = bitmap.GetPixel(0, bitmap.Height-1);
            int colOpaquePixel = 0;           
            for (int row = 0; row < bitmap.Height; row++)
            {               
                colOpaquePixel = 0;
                for (int col = 0; col < bitmap.Width; col++)
                {                    
                    if (bitmap.GetPixel(col, row) != colorTransparent)
                    {                       
                        colOpaquePixel = col;
                        int colNext = col;
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == colorTransparent)
                                break;
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));                        
                        col = colNext;
                    }
                }
            }
            return graphicsPath;
        }
    }
}
