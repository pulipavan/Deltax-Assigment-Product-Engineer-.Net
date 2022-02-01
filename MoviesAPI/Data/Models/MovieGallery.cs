using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Models
{
    public class MovieGallery
    {
        [Key]
        public int pic_id { get; set; }
        public string pic_path { get; set; }
        public int movie_id { get; set; }
        public Movie movie { get; set; }
    }
}
