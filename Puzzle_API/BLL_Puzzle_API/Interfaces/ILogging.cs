using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Puzzle_API.Interfaces
{
    public interface ILogging
    {
        public void SaveError(string methodName, string message, string stackTrace, string innerException, string requestValue = null);
    }
}
