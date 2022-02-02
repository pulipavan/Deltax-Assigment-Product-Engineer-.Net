using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Models
{
    public class Producer
    {
        [Key]
        public int producer_id { get; set; }
        public string producer_name { get; set; }
        public string company_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
    }
}
