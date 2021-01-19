using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Puzzle_API.Models
{
    public partial class PuzzleError
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime? Created { get; set; }
        public string InnerExceprion { get; set; }
        public string Requst { get; set; }
    }
}
