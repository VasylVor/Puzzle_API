using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Puzzle_API.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageValue { get; set; }
        public DateTime? Created { get; set; }
    }
}
