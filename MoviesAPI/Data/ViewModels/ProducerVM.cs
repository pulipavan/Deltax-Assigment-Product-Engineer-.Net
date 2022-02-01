using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.ViewModels
{
    public class ProducerVM
    {
        public string producer_name { get; set; }
        public string company_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
    }
}
