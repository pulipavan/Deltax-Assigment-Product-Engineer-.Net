using MoviesAPI.Data.Models;
using MoviesAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data.Services
{
    public class ActorServices
    {
        private AppDbContext _context;

        public ActorServices(AppDbContext context)
        {
            _context = context;
        }

        public List<ActorWithoutMovieVM> GetAllActors()
        {
            var _actorWithoutMovieVMs = _context.Actors.Select(actor => new ActorWithoutMovieVM()
            {
                actor_id = actor.actor_id,
                actor_name = actor.actor_name,
                biodata = actor.biodata,
                date_of_birth = actor.date_of_birth,
                gender = actor.gender
            }).ToList();

            return _actorWithoutMovieVMs;
        }

        public ActorWithoutMovieVM GetActorById(int actorId)
        {
            var _actorWithoutMovieVM = _context.Actors.Where(a => a.actor_id == actorId).Select(actor => new ActorWithoutMovieVM()
            {
                actor_id = actor.actor_id,
                actor_name = actor.actor_name,
                biodata = actor.biodata,
                date_of_birth = actor.date_of_birth,
                gender = actor.gender
            }).FirstOrDefault();

            return _actorWithoutMovieVM;
        }

        public int AddActor(ActorVM actor)
        {
            var _actor = new Actor()
            {
                actor_name = actor.actor_name,
                biodata = actor.biodata,
                date_of_birth = actor.date_of_birth,
                gender = actor.gender
            };

            _context.Actors.Add(_actor);
            _context.SaveChanges();

            return _actor.actor_id; 
        }

        public bool UpdateActor(int actorId, ActorVM actor)
        {
            var _actor = _context.Actors.FirstOrDefault(a => a.actor_id == actorId);

            if(_actor != null)
            {
                _actor.actor_name = actor.actor_name;
                _actor.biodata = actor.biodata;
                _actor.date_of_birth = actor.date_of_birth;
                _actor.gender = actor.gender;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteActorById(int actorId)
        {
            var _actor = _context.Actors.FirstOrDefault(a => a.actor_id == actorId);

            if (_actor != null)
            {
                _context.Actors.Remove(_actor);
                _context.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
