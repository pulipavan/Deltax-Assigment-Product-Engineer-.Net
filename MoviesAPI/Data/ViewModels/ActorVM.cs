using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.ViewModels
{
    public class ActorVM
    {
        public string actor_name { get; set; }
        public string biodata { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
    }

    public class ActorWithoutMovieVM
    {
        public int actor_id { get; set; }
        public string actor_name { get; set; }
        public string biodata { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
    }
}
