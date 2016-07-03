using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Dramonkiller.HappyGrandpaCareHome.Core.Extensions
{
    public static class ImageExtensions
    {
        public static Bitmap Resize(this Image image, int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height);
            //this is what allows the quality to stay the same when reducing image dimensions
            newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(image, new Rectangle(0, 0, width, height));
            }

            return newImage;
        }

        public static byte[] ToByteArray(this Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);

                return ms.ToArray(); 
            }
        } 
    }
}
