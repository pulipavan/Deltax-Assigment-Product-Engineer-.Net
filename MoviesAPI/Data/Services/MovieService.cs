using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.Data;
using MoviesAPI.Data.Models;
using MoviesAPI.Data.ViewModels;

namespace MoviesAPI.Movies.Services
{
    public class MovieService
    {
        private AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public List<MovieWithNamesVM> GetAllMovies()
        {
            var _movieWithNamesVMs = _context.Movies.Select(movie => new MovieWithNamesVM()
            {
                movie_id = movie.movie_id,
                movie_name = movie.movie_name,
                date_of_release = movie.date_of_release,
                movieactors = movie.movieactors.Select(ma => ma.actor.actor_name).ToList(),
                producer_name = movie.producer.producer_name,
                movie_images = movie.movie_galleries.Select(mg => mg.pic_path).ToList()
            }).ToList();

            return _movieWithNamesVMs;
        }

        public MovieWithNamesVM GetMovieById(int movieId)
        {
            var _movieWithNamesVM = _context.Movies.Where(m => m.movie_id == movieId).Select(movie => new MovieWithNamesVM()
            {
                movie_id = movie.movie_id,
                movie_name = movie.movie_name,
                date_of_release = movie.date_of_release,
                movieactors = movie.movieactors.Select(ma => ma.actor.actor_name).ToList(),
                producer_name = movie.producer.producer_name,
                movie_images = movie.movie_galleries.Select(mg => mg.pic_path).ToList()
            }).FirstOrDefault();

            return _movieWithNamesVM;
        }

        public void AddMovie(MovieVM movie)
        {
            var _movie = new Movie()
            {
                movie_name = movie.movie_name,
                description = movie.description,
                date_of_release = movie.date_of_release,
                producer_id = movie.producer_id,
            };
            _context.Movies.Add(_movie);
            _context.SaveChanges();

            foreach(var actorId in movie.actor_ids)
            {
                var _movie_actors = new MovieActor()
                {
                    movie_id = _movie.movie_id,
                    actor_id = actorId
                };
                _context.MovieActors.Add(_movie_actors);
                _context.SaveChanges();
            }

            foreach (var path in movie.movie_image_paths)
            {
                var _movie_gallery = new MovieGallery()
                {
                    movie_id = _movie.movie_id,
                    pic_path = path
                };
                _context.Movie_galleries.Add(_movie_gallery);
                _context.SaveChanges();
            }
        }
    }
}
