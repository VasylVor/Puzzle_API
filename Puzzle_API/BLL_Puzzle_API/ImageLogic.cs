using BLL_Puzzle_API.Interfaces;
using DAL_Puzzle_API;
using DAL_Puzzle_API.Interfaces;
using DAL_Puzzle_API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Puzzle_API
{
    public class ImageLogic : Interfaces.IImage
    {
        private readonly PuzzleDBContext context;
      //  private readonly DAL_Puzzle_API.Interfaces.ILogging logger;
        private readonly ImageRepository imageRepository;
        public ImageLogic() 
        {
            context = new PuzzleDBContext();
           // logger = new LoggerRepository(context);
            imageRepository = new ImageRepository(context);
        }


        
        public List<Image> GetImages()
        {
            List<Image> imalgeLst = new List<Image>();

            try
            {
                imalgeLst = imageRepository.GetImages();
               return imalgeLst;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return imalgeLst;
            }
        }

        public List<Image> GetImages(int id)
        {
            List<Image> imalgeLst = new List<Image>();

            try
            {
                imalgeLst = imageRepository.GetImages(id);
                return imalgeLst;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return imalgeLst;
            }
        }

        public List<Image> GetImages(string name)
        {
            List<Image> imalgeLst = new List<Image>();
            try
            {
                imalgeLst = imageRepository.GetImages(name);
                return imalgeLst;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return imalgeLst;
            }
        }

        public int? SaveImage(string name, string image)
        {
            int? id = null;
            try
            {
                imageRepository.SaveImage(name, image, out id);
                return id;
            }
            catch (Exception e)
            {

                MethodBase method = MethodBase.GetCurrentMethod();
                new LoggingLogic().SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return id;
            }
        }
    }
}
