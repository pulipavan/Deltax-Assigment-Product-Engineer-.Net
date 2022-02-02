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
    public class ProducersController : ControllerBase
    {
        private ProducerServices _producerServices;

        public ProducersController(ProducerServices producerServices)
        {
            _producerServices = producerServices;
        }

        // GET: api/Producers
        [HttpGet]
        public IActionResult GetAllProducers()
        {
            var producers = _producerServices.GetAllProducers();
            return Ok(producers);
        }

        // GET api/Producers/5
        [HttpGet("{producerId}")]
        public IActionResult GetProducerById(int producerId)
        {
            var producer = _producerServices.GetProducerById(producerId);
            
            if (producer == null)
                return NotFound();

            return Ok(producer);
        }

        // POST api/Producers
        [HttpPost]
        public IActionResult AddProducer([FromBody] ProducerVM producer)
        {
            int producerId = _producerServices.AddProducer(producer);
            var result = "{ \"producer_id\": " + producerId + " }";
            return Ok(result);
        }

        // PUT api/Producers/5
        [HttpPut("{producerId}")]
        public IActionResult UpdateProducer(int producerId, [FromBody] ProducerVM producer)
        {

            return Ok();
        }

        // DELETE api/Producers/5
        [HttpDelete("{producerId}")]
        public IActionResult DeleteProducerById(int producerId)
        {
            bool isDeleted = _producerServices.DeleteProducerById(producerId);

            if (isDeleted == false)
                return NotFound();

            return NoContent();
        }
    }
}
