using DAL_Puzzle_API;
using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Puzzle_API.Operations
{
    static class ImageBLL
    {
       // public static LoggerRepository Logger { get; set; }
        internal static Bitmap[,] CutImage(int userWidth, int userHeight, System.Drawing.Image image)
        {
            Bitmap[,] bmps = new Bitmap[0,0];
            try
            {
                var (width, height) = GetImageParamiters(userWidth, userHeight, image);
                bmps = new Bitmap[height, width];
                //PuzzleRepository rp = new PuzzleRepository(new PuzzleDBContext());

                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                    {
                        bmps[i, j] = new Bitmap(userWidth, userHeight);
                        Graphics g = Graphics.FromImage(bmps[i, j]);
                        g.DrawImage(image, new Rectangle(0, 0, userWidth, userHeight), new Rectangle(j * userWidth, i * userHeight, userWidth, userHeight), GraphicsUnit.Pixel);
                        g.Dispose();
                    }

                return bmps;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return bmps;
            }
        }

        private static (int width, int height) GetImageParamiters(int userWidth, int userHeight, System.Drawing.Image image)
        {
            try
            {
                int width = image.Width / userWidth;
                int height = image.Height / userHeight;

                return (width, height);
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return (0,0);
            }
        }
        

        public static System.Drawing.Image ConvertImage(string bimage)
        {
            try
            {
                //  PuzzleRepository rp = new PuzzleRepository(new PuzzleDBContext());

                int index = bimage.IndexOf(',') + 1;

                //string imgType = bimage.Remove(index, bimage.Length - index);

                var bytes = Convert.FromBase64String(bimage.Remove(0, index));

                System.Drawing.Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = System.Drawing.Image.FromStream(ms);
                }

                return image;

            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return null;
            }        
        }

        public static string ConvertImage(System.Drawing.Image image)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();

                string img = Convert.ToBase64String(byteImage);
                return img;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return null;
            }
        }
    }
}
