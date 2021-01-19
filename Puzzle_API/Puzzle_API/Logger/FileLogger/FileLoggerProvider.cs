using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle_API.Logger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string path;

        public FileLoggerProvider(string _path)
        {
            path = _path;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        public void Dispose()
        {
        }
    }
}
