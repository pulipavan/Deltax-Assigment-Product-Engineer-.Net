using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Models
{
    public class Movie
    {
        [Key]
        public int movie_id { get; set; }
        public string movie_name { get; set; }
        public string description { get; set; }
        public DateTime date_of_release { get; set; }
        public int? producer_id { get; set; }
        public ICollection<MovieActor> movieactors { get; set; }
        public Producer producer { get; set; }
        public ICollection<MovieGallery> movie_galleries { get; set; }
    }
}
