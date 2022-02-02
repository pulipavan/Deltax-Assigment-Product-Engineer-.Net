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
    public class MoviesController : ControllerBase
    {
        private MovieServices _movieServices;

        public MoviesController(MovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        // GET: api/MovieGalleries
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movieGalleries = _movieServices.GetAllMovies();
            return Ok(movieGalleries);
        }

        // GET api/MovieGalleries/5
        [HttpGet("{movieId}")]
        public IActionResult GetMovieById(int movieId)
        {
            var movie = _movieServices.GetMovieById(movieId);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST api/MovieGalleries
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            int movieId = _movieServices.AddMovie(movie);
            var result = "{ \"movie_id\": " + movieId + " }";
            return Ok(result);
        }

        // PUT api/MovieGalleries/5
        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(int movieId, [FromBody] MovieVM movie)
        {
            bool isUpdated = _movieServices.UpdateMovie(movieId, movie);

            if (isUpdated == false)
                return NotFound();

            return Ok();
        }

        // DELETE api/MovieGalleries/5
        [HttpDelete("{movieId}")]
        public IActionResult DeleteMovieById(int movieId)
        {
            bool isDeleted = _movieServices.DeleteMovieById(movieId);

            if (isDeleted == false)
                return NotFound();

            return NoContent();
        }
    }
}
