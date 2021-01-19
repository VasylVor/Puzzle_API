using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Puzzle_API.Interfaces
{
    public interface IPuzzle
    {
        public List<string> CreatePuzzle(int userWidth, int userHeight, string image, string name);
        public bool CheckPuzzle(int id, List<string> userPuzzles);
        public List<Puzzle> GetPuzzles(int idImage);
    }
}
