using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle_API.Model.RequestObjects
{
    public class SaveImageRequest
    {
        public int IdImage { get; set; }
        public List<string> Puzzels { get; set; }
    }
}
