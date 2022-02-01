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

        public void AddProducer(ProducerVM actor)
        {
            var _actor = new Producer()
            {
                producer_name = actor.producer_name,
                company_name = actor.company_name,
                date_of_birth = actor.date_of_birth,
                gender = actor.gender
            };

            _context.Producers.Add(_actor);
            _context.SaveChanges();
        }

        public Producer UpdateProducer(int actorId, ProducerVM actor)
        {
            var _actor = _context.Producers.FirstOrDefault(a => a.producer_id == actorId);

            if (_actor != null)
            {
                _actor.producer_name = actor.producer_name;
                _actor.company_name = actor.company_name;
                _actor.date_of_birth = actor.date_of_birth;
                _actor.gender = actor.gender;

                _context.SaveChanges();
            }

            return _actor;
        }

        public void DeleteProducerById(int producerId)
        {
            var _actor = _context.Producers.FirstOrDefault(a => a.producer_id == producerId);

            if (_actor != null)
            {
                _context.Producers.Remove(_actor);
                _context.SaveChanges();
            }
        }
    }
}
