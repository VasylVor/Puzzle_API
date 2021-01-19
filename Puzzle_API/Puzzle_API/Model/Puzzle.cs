using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle_API.Model
{
    public class Puzzle
    {
        public int Id { get; set; }
        public int? IdImage { get; set; }
        public string PuzzleImg { get; set; }
    }
}
