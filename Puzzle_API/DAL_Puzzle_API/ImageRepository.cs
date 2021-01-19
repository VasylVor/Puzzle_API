using DAL_Puzzle_API.Interfaces;
using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Puzzle_API
{
    public class ImageRepository : IImage
    {
        private readonly PuzzleDBContext context;
        private readonly ILogging logger;
        public ImageRepository(PuzzleDBContext _context)
        {
            context = _context;// new PuzzleDBContext();//for test
            logger = new LoggerRepository(context);
        }
        public List<Image> GetImages()
        {
            try
            {
                return context.Images.Select(s => new Image() { Name = s.Name, Id = s.Id, Created = s.Created }).ToList();
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logger.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return new List<Image>();
            }
        }
        public List<Image> GetImages(int id)
        {
            return context.Images.Where(w => w.Id == id).Select(s => new Image() { Name = s.Name, Id = s.Id, Created = s.Created }).ToList();
        }

        public List<Image> GetImages(string name)
        {
            return context.Images.Where(w => w.Name == name).Select(s => new Image() { Name = s.Name, Id = s.Id, Created = s.Created }).ToList();
        }

        public bool SaveImage(string name, string image, out int? id)
        {
            id = null;

            try
            {
                Image img = new Image()
                {
                    Name = name,   
                    ImageValue = image
                };

                context.Images.Add(img);
                context.SaveChanges();
                id = img.Id;
                return true;
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logger.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return false;
            }
        }
    }
}
