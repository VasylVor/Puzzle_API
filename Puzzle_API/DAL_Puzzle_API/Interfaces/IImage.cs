using DAL_Puzzle_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Puzzle_API.Interfaces
{
    public interface IImage
    {
        public List<Image> GetImages();
        public List<Image> GetImages(int id);
        public List<Image> GetImages(string name);

        bool SaveImage(string name, string image, out int? id);
    }
}
