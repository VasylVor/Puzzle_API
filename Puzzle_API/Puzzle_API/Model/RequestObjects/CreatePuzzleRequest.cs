using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle_API.Model.RequestObjects
{
    public class CreatePuzzleRequest
    {
        //int userWidth, int userHeight, string image, string name
        public int WidthPuzzle { get; set; }
        public int HeightPuzzle { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
