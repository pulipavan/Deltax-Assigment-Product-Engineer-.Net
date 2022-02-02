using MoviesAPI.Data.Models;
using MoviesAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Services
{
    public class MovieGalleryServices
    {
        private AppDbContext _context;

        public MovieGalleryServices(AppDbContext context)
        {
            _context = context;
        }

        public List<MovieGalleryWithMovieVM> GetAllMovieGalleries()
        {
            var _movieGalleryWithMovieVMs =  _context.Movie_galleries.Select(movieGallery => new MovieGalleryWithMovieVM()
            {
                pic_id = movieGallery.pic_id,
                pic_path = movieGallery.pic_path,
                movie_name = movieGallery.movie.movie_name
            }).ToList();

            return _movieGalleryWithMovieVMs;

        }

        public MovieGalleryWithMovieVM GetMovieGalleryById(int picId)
        {
            var _movieGalleryWithMovieVM = _context.Movie_galleries.Where(a => a.pic_id == picId).Select(movieGallery => new MovieGalleryWithMovieVM()
            {
                pic_id = movieGallery.pic_id,
                pic_path = movieGallery.pic_path,
                movie_name = movieGallery.movie.movie_name
            }).FirstOrDefault();

            return _movieGalleryWithMovieVM;
            
        }

        public int AddMovieGallery(MovieGalleryVM movieGallery)
        {
            var _movieGallery = new MovieGallery()
            {
                pic_path = movieGallery.pic_path,
                movie_id = movieGallery.movie_id
            };

            _context.Movie_galleries.Add(_movieGallery);
            _context.SaveChanges();

            return _movieGallery.pic_id;
        }

        public bool UpdateMovieGallery(int picId, MovieGalleryVM movieGallery)
        {
            var _movieGallery = _context.Movie_galleries.FirstOrDefault(a => a.pic_id == picId);

            if (_movieGallery != null)
            {
                _movieGallery.pic_path = movieGallery.pic_path;
                _movieGallery.movie_id = movieGallery.movie_id;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteMovieGalleryById(int picId)
        {
            var _movieGallery = _context.Movie_galleries.FirstOrDefault(a => a.pic_id == picId);

            if (_movieGallery != null)
            {
                _context.Movie_galleries.Remove(_movieGallery);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
