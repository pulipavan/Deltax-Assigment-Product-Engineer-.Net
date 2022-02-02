using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Models
{
    public class MovieActor
    {
        public int movie_id { get; set; }
        public Movie movie { get; set; }
        public int actor_id { get; set; }
        public Actor actor { get; set; }
    }
}
