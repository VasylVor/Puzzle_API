using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Puzzle_API.Interfaces
{
    public interface IImage
    {
        public int? SaveImage(string name, string image);
        public List<Image> GetImages();
        public List<Image> GetImages(int id);
        public List<Image> GetImages(string name);
    }
}
