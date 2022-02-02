using MoviesAPI.Data.Models;
using MoviesAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Services
{
    public class ProducerServices
    {
        private AppDbContext _context;

        public ProducerServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Producer> GetAllProducers()
        {
            return _context.Producers.ToList();
        }

        public Producer GetProducerById(int producerId)
        {
            return _context.Producers.FirstOrDefault(a => a.producer_id == producerId);
        }

        public int AddProducer(ProducerVM producer)
        {
            var _producer = new Producer()
            {
                producer_name = producer.producer_name,
                company_name = producer.company_name,
                date_of_birth = producer.date_of_birth,
                gender = producer.gender
            };

            _context.Producers.Add(_producer);
            _context.SaveChanges();

            return _producer.producer_id;
        }

        public Producer UpdateProducer(int producerId, ProducerVM producer)
        {
            var _producer = _context.Producers.FirstOrDefault(a => a.producer_id == producerId);

            if (_producer != null)
            {
                _producer.producer_name = producer.producer_name;
                _producer.company_name = producer.company_name;
                _producer.date_of_birth = producer.date_of_birth;
                _producer.gender = producer.gender;

                _context.SaveChanges();
            }

            return _producer;
        }

        public bool DeleteProducerById(int producerId)
        {
            var _producer = _context.Producers.FirstOrDefault(a => a.producer_id == producerId);

            if (_producer != null)
            {
                _context.Producers.Remove(_producer);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
