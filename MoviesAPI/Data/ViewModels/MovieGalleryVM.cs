using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.ViewModels
{
    public class MovieGalleryVM
    {
        public string pic_path { get; set; }
        public int movie_id { get; set; }
    }

    public class MovieGalleryWithMovieVM
    {
        public string pic_path { get; set; }
        public string movie_name { get; set; }
    }
}
