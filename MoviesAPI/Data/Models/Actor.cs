using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Models
{
    public class Actor
    {
        [Key]
        public int actor_id { get; set; }
        public string actor_name { get; set; }
        public string biodata { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
        public ICollection<MovieActor> movieactors { get; set; }
    }
}
