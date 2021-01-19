using BLL_Puzzle_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPuzzle_API.Model.ResponseObjects;
using Puzzle_API.Model;
using Puzzle_API.Model.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Puzzle_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImage image;
        private readonly ILogging logging;
        public ImageController(IImage _image, ILogging _logging)
        {
            image = _image;
            logging = _logging;
        }
        // GET: api/<ImageController>
        [HttpGet]
        [Route("GetImages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ImageResponse> GetImages()
        {
            try
            {
                List<Image> images = new List<Image>();
                images = image.GetImages().Select(s => new Image() { Id = s.Id, ImageValue = s.ImageValue, Name = s.Name}).ToList();
                throw new Exception();
                if (images.Count > 0)
                {
                    ImageResponse response = new ImageResponse()
                    {
                        Image = images,
                        
                    };

                    return Ok(response);
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {

                MethodBase method = MethodBase.GetCurrentMethod();
                logging.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message);
                return BadRequest();
            }
        }

        // GET api/<ImageController>/5
        [HttpGet]
        [Route("GetImagesById/{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ImageResponse> GetImagesById(int id)
        {
            try
            {
                List<Image> images = new List<Image>();
                images = image.GetImages(id).Select(s => new Image() { Id = s.Id, ImageValue = s.ImageValue, Name = s.Name }).ToList();

                if (images.Count > 0)
                {
                    ImageResponse response = new ImageResponse()
                    {
                        Image = images
                    };

                    return Ok(response);
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logging.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message, $"request: id={id}");
                return BadRequest();
            }
        }

        // GET api/<ImageController>/5
        [HttpGet]
        [Route("GetImagesByName/{name}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ImageResponse> GetImagesByName(string name)
        {
            try
            {
                List<Image> images = new List<Image>();
                images = image.GetImages(name).Select(s => new Image() { Id = s.Id, ImageValue = s.ImageValue, Name = s.Name }).ToList();

                if (images.Count > 0)
                {
                    ImageResponse response = new ImageResponse()
                    {
                        Image = images,
                        //ResponseParam = ResponseServ.Ok()
                    };

                    return Ok(response);
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {

                MethodBase method = MethodBase.GetCurrentMethod();
                logging.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message, $"request:  Name={name}");
                return BadRequest();
            }
        }

        // POST api/<ImageController>
        [HttpPost]
        [Route("SaveImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> SaveImage([FromBody] Image imageReq)
        {
            try
            {
               int? id = image.SaveImage(imageReq.Name, imageReq.ImageValue);
                if (id != null)
                {
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                logging.SaveError(method.ReflectedType.FullName, e.Message, e.StackTrace, e.InnerException?.Message, $"request: ImageValue = {imageReq.ImageValue}; Name={imageReq.Name}");
                return BadRequest();
            }
        }

    }
}
