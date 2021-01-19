using DAL_Puzzle_API.Interfaces;
using DAL_Puzzle_API.Models;
using System;

namespace DAL_Puzzle_API
{
    public class LoggerRepository : ILogging
    {
        private readonly PuzzleDBContext context;

        public LoggerRepository(PuzzleDBContext _context)
        {
            this.context = _context;//new PuzzleDBContext();//for test
        }
        public void SaveError(string methodName, string message, string stackTrace, string innerException, string requestValue = null)
        {
            context.PuzzleErrors.Add(new PuzzleError() { InnerExceprion = innerException, MethodName = methodName, Message = message, StackTrace = stackTrace, Requst = requestValue});
        }

    }
}
