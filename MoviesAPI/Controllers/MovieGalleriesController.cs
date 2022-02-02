using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data.Services;
using MoviesAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGalleriesController : ControllerBase
    {
        private MovieGalleryServices _movieGalleryServices;

        public MovieGalleriesController(MovieGalleryServices movieGalleryServices)
        {
            _movieGalleryServices = movieGalleryServices;
        }

        // GET: api/MovieGalleries
        [HttpGet]
        public IActionResult GetAllMovieGalleries()
        {
            var movieGalleries = _movieGalleryServices.GetAllMovieGalleries();
            return Ok(movieGalleries);
        }

        // GET api/MovieGalleries/5
        [HttpGet("{picId}")]
        public IActionResult GetMovieGalleryById(int picId)
        {
            var movieGallery = _movieGalleryServices.GetMovieGalleryById(picId);

            if (movieGallery == null)
                return NotFound();

            return Ok(movieGallery);
        }

        // POST api/MovieGalleries
        [HttpPost]
        public IActionResult AddMovieGallery([FromBody] MovieGalleryVM movieGallery)
        {
            int picId = _movieGalleryServices.AddMovieGallery(movieGallery);
            var result = "{ \"pic_id\": " + picId + " }";
            return Ok(result);
        }

        // PUT api/MovieGalleries/5
        [HttpPut("{picId}")]
        public IActionResult UpdateMovieGallery(int picId, [FromBody] MovieGalleryVM movieGallery)
        {
            bool isUpdated = _movieGalleryServices.UpdateMovieGallery(picId, movieGallery);

            if (isUpdated == false)
                return NotFound();

            return Ok();
        }

        // DELETE api/MovieGalleries/5
        [HttpDelete("{picId}")]
        public IActionResult DeleteMovieGalleryById(int picId)
        {
            bool isDeleted = _movieGalleryServices.DeleteMovieGalleryById(picId);

            if (isDeleted == false)
                return NotFound();

            return NoContent();
        }
    }
}
