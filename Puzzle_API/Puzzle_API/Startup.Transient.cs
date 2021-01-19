using BLL_Puzzle_API;
using BLL_Puzzle_API.Interfaces;
using DAL_Puzzle_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Puzzle_API.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle_API
{
    public partial class Startup
    {
        void SetUpDependevies(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Puzzle_API",
                    Description = "Documentation for Puzzle_API"
                });            
            });

            services.AddTransient<IImage, ImageLogic>();
            services.AddTransient<IPuzzle, PuzzleLogic>();
            services.AddTransient<ILogging, LoggingLogic>();
        }

        
        void CingiguarationOptions(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Puzzle_API");
                s.RoutePrefix = string.Empty;
            });

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

            var logger = loggerFactory.CreateLogger("FileLogger");
        }
    }
}
