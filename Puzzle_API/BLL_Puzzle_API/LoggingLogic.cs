using BLL_Puzzle_API.Interfaces;
using DAL_Puzzle_API;
using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Puzzle_API
{
    public class LoggingLogic : ILogging
    {
        private readonly PuzzleDBContext context;
        private readonly DAL_Puzzle_API.Interfaces.ILogging logger;


        public LoggingLogic()
        {
            context = new PuzzleDBContext();
            logger = new LoggerRepository(context);
        }
        public void SaveError(string methodName, string message, string stackTrace, string innerException, string requestValue = null)
        {
            logger.SaveError(methodName, message, stackTrace, innerException, requestValue);
        }
    }
}
