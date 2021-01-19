using BLL_Puzzle_API;
using BLL_Puzzle_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puzzle_API.Model;
using Puzzle_API.Model.RequestObjects;
using Puzzle_API.Model.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Puzzle_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PuzzleController : ControllerBase
    {
        private readonly IPuzzle puzzle;
        private readonly ILogging logging;
        public PuzzleController(IPuzzle _puzzle, ILogging _logging)
        {
            puzzle = _puzzle;
            logging = _logging;
        }

        [HttpGet]
        [Route("GetPuzzle/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PuzzleResponse> GetPuzzle(int id)
        {
            try
            {
                var puzzRep = puzzle.GetPuzzles(id).FirstOrDefault();

                if (puzzRep != null)
                {
                    PuzzleResponse response = new PuzzleResponse()
                    {
                        Puzzle = new Puzzle()
                        {
                            Id = puzzRep.Id,
                            IdImage = puzzRep.IdImage,
                            PuzzleImg = puzzRep.PuzzleImg
                        }
                    };
                    return Ok(response);
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logging.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message,$"request: Id = {id}" );
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CheckPuzzle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CheckPuzzle([FromBody] SaveImageRequest request)
        {
            try
            {
                bool flag = puzzle.CheckPuzzle(request.IdImage, request.Puzzels);
                if (flag)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logging.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message, $"request: IdImage = {request.IdImage};");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CreatePuzzle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<string>> CreatePuzzle([FromBody] CreatePuzzleRequest request)
        {
            try
            {
                List<string> puzzels = puzzle.CreatePuzzle(request.WidthPuzzle, request.HeightPuzzle, request.Image,
                    request.Name);
                if (puzzle != null)
                    return Ok(puzzels);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logging.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message, $"request: WidthPuzzle = {request.WidthPuzzle}; HeightPuzzle = {request.HeightPuzzle}; " +
                    $"Image = {request.Image}; Name={request.Name}");
                return BadRequest();
            }
        }
    }
}
