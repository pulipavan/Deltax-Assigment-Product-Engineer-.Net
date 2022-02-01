using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.ViewModels
{
    public class MovieVM
    {
        public string movie_name { get; set; }
        public string description { get; set; }
        public DateTime date_of_release { get; set; }
        public List<int> actor_ids { get; set; }
        public int producer_id { get; set; }
        public List<string> movie_image_paths { get; set; }
    }

    public class MovieWithNamesVM
    {
        public int movie_id { get; set; }
        public string movie_name { get; set; }
        public string description { get; set; }
        public DateTime date_of_release { get; set; }
        public List<string> movieactors { get; set; }
        public string producer_name { get; set; }
        public List<string> movie_images { get; set; }
    }
}
