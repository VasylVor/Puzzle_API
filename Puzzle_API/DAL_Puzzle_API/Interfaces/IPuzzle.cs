using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Puzzle_API.Interfaces
{
    public interface IPuzzle
    {
        public List<Puzzle> GetPuzzles(int idImage);
        public bool SavePuzzle(Puzzle puzzle);
    }
}
