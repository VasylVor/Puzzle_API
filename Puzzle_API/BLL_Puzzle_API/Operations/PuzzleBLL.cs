using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Puzzle_API.Operations
{
    class PuzzleBLL
    {
        /// <summary>
        /// Змішування пазлів(алгортм Фишера-Йетса)
        /// </summary>
        /// <param name="bitmaps"></param>
        /// <returns></returns>
        public static List<string> MixPuzzle(Bitmap[,] bitmapsPuzzle)
        {
            List<string> lstImage = new List<string>();
            try
            {

                Random rnd = new Random();
                Bitmap[,] clone = bitmapsPuzzle;
                for (int i = bitmapsPuzzle.GetLength(0) - 1; i >= 1; i--)
                {
                    for (int j = bitmapsPuzzle.GetLength(1) - 1; j >= 1; j--)
                    {
                        int r1 = rnd.Next(0, i + 1);
                        int r2 = rnd.Next(0, j + 1);

                        var temp = bitmapsPuzzle[r1, r2];
                        bitmapsPuzzle[r1, r2] = bitmapsPuzzle[i, j];
                        bitmapsPuzzle[i, j] = temp;
                    }
                }

                lstImage = GetPuzzleList(bitmapsPuzzle);
                return lstImage;

            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return lstImage;
            }        
        }

        private static List<string> GetPuzzleList(Bitmap[,] puzzles)
        {
            List<string> lstImage = new List<string>();

            try
            {
                for (int i = 0; i < puzzles.GetLength(0); i++)
                {
                    for (int j = 0; j < puzzles.GetLength(1); j++)
                    {
                        string imgPuz = ImageBLL.ConvertImage(puzzles[i, j]);
                        lstImage.Add(imgPuz);
                    }
                }

                return lstImage;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return lstImage;
            }
        }
    }
}
