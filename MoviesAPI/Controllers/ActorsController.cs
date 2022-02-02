using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data.Services;
using MoviesAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        public ActorServices _actorServices;

        public ActorsController(ActorServices actorServices)
        {
            _actorServices = actorServices;
        }

        // GET: api/Actors
        [HttpGet]
        public IActionResult GetAllActors()
        {
            var actors = _actorServices.GetAllActors();
            return Ok(actors);
        }

        // GET api/Actors/5
        [HttpGet("{actorId}")]
        public IActionResult GetActorById(int actorId)
        {
            var actor = _actorServices.GetActorById(actorId);

            if (actor == null)
                 return NotFound();

            return Ok(actor);
        }

        // POST api/Actors
        [HttpPost]
        public IActionResult AddActor([FromBody] ActorVM actor)
        {
            int actorId = _actorServices.AddActor(actor);
            string result = "{ \"actor_id\": " + actorId + " }"; 
            return Ok(result);
        }

        // PUT api/Actors/5
        [HttpPut("{actorId}")]
        public IActionResult UpdateActor(int actorId, [FromBody] ActorVM actor)
        {
            bool isUpdated = _actorServices.UpdateActor(actorId, actor);
            
            if (isUpdated == false)
                return NotFound();

            return Ok();
        }

        // DELETE api/Actors>/5
        [HttpDelete("{actorId}")]
        public IActionResult Delete(int actorId)
        {
            bool isDeleted = _actorServices.DeleteActorById(actorId);

            if (isDeleted == false)
                return NotFound();

            return NoContent();
        }
    }
}
