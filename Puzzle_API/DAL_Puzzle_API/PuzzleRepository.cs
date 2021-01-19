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
    public class PuzzleRepository : IPuzzle
    {
        private readonly PuzzleDBContext context;
        private readonly ILogging logger;

        public PuzzleRepository(PuzzleDBContext _context)
        {
            context = _context;//new PuzzleDBContext();//for test
            logger = new LoggerRepository(context);

        }
        public List<Puzzle> GetPuzzles(int idImage)
        {
            try
            {
                return context.Puzzles.Where(w => w.IdImage == idImage).Select(s => new Puzzle() { Id = s.Id, IdImage = s.IdImage, Created = s.Created }).ToList();
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logger.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return new List<Puzzle>();
            }
        }

        public bool SavePuzzle(Puzzle puzzle)
        {
            try
            {
                context.Puzzles.Add(puzzle);
                context.SaveChanges();
                
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

