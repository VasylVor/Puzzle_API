
using DAL_Puzzle_API;
using DAL_Puzzle_API.Interfaces;
using DAL_Puzzle_API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //IImage image = new ImageRepository(new PuzzleDBContext(GetConnectionString()));
           // var a = image.SaveImage("test1", "test2");
            Console.ReadLine();
        }

        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("PuzzleDB");

            return connectionString;
        }

    }
}
