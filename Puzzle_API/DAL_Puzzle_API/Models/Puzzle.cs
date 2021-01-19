using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Puzzle_API.Models
{
    public partial class Puzzle
    {
        public int Id { get; set; }
        public int? IdImage { get; set; }
        public string PuzzleImg { get; set; }
        public DateTime? Created { get; set; }
    }
}
