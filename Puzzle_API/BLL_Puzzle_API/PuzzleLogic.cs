using BLL_Puzzle_API.Interfaces;
using BLL_Puzzle_API.Operations;
using DAL_Puzzle_API;
using DAL_Puzzle_API.Interfaces;
using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace BLL_Puzzle_API
{
    public class PuzzleLogic : Interfaces.IPuzzle
    {
        private readonly PuzzleDBContext context;
       // private readonly DAL_Puzzle_API.Interfaces.ILogging logger;
        private readonly ImageRepository imageRepository;
        private readonly PuzzleRepository puzzleRepository;

        public PuzzleLogic()
        {
            context = new PuzzleDBContext();
          //  logger = new LoggerRepository(context);
            imageRepository = new ImageRepository(context);
            puzzleRepository = new PuzzleRepository(context);
          //  ImageBLL.Logger = new LoggerRepository(context);
        }
       
        public bool CheckPuzzle( int id, List<string> userPuzzles)
        {
            try
            {
                List<Puzzle> rightPuzzles = puzzleRepository.GetPuzzles(id);
                if (rightPuzzles == null)
                    return false;

                for (int i = 0; i < userPuzzles.Count; i++)
                {
                    if (userPuzzles[i] != rightPuzzles[i].PuzzleImg)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return false;
            }
        }

        public List<string> CreatePuzzle(int userWidth, int userHeight, string image, string name)
        {
            List<string> lstPuzzel = new List<string>();
            try
            {
                System.Drawing.Image img = ImageBLL.ConvertImage(image);

                bool flageRep = imageRepository.SaveImage(name, image, out int? idPuzzle);
                if (!CheckFlag(flageRep))
                    return lstPuzzel;

                var puzzels = ImageBLL.CutImage(userWidth, userHeight, img);
                foreach (var puzzel in puzzels)
                    flageRep = puzzleRepository.SavePuzzle(new Puzzle() { IdImage = idPuzzle, PuzzleImg = ImageBLL.ConvertImage(puzzel) });

                if (!CheckFlag(flageRep))
                    return lstPuzzel;

                lstPuzzel = PuzzleBLL.MixPuzzle(puzzels);
                return lstPuzzel;
                // Repository.SavePuzzle(id, type + ConvertFromImageToBase64(bmps[i, j]));
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return lstPuzzel;
            }
        }

        private static bool CheckFlag(bool flage)
        {
            if (flage)
                return true;
            else
                return false;
        }

        public List<Puzzle> GetPuzzles(int idImage)
        {
            List<Puzzle> puzzleLst = new List<Puzzle>();
            try
            {
                puzzleLst = puzzleRepository.GetPuzzles(idImage);
                return puzzleLst;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return puzzleLst;
            }
        }
    }
}
