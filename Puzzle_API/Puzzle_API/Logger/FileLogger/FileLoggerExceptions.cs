using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle_API.Logger
{
    public static class FileLoggerExceptions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string path)
        {
            factory.AddProvider(new FileLoggerProvider(path));
            return factory;
        }
    }
}
