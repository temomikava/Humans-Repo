using AutoMapper;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumansAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectedHumansController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepository<Human> humans;
        private readonly IRepository<HumanConnection> humanConnections;

        public ConnectedHumansController(IMapper mapper,IRepository<Human> humans,IRepository<HumanConnection> humanConnections)
        {
            this.mapper = mapper;
            this.humans = humans;
            this.humanConnections = humanConnections;
        }
       

        // POST api/<ConnectedHumansController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddConnectedHumanRequest request)
        {
            var connectionAlreadyExists = humanConnections.CheckAsync(x => (x.FirstHumanId == request.FirstHumanId && x.SecondHumanId == request.SecondHumanId)
                                        || (x.FirstHumanId == request.SecondHumanId && x.SecondHumanId == request.FirstHumanId)).Result;
            if (request.FirstHumanId==request.SecondHumanId)
            {
                return BadRequest("FirstHumanId and SecondHumanId should be different");
            }
            if (connectionAlreadyExists)
            {
                return BadRequest("connection between this users already exists");
            }
            await humanConnections.CreateAsync(mapper.Map<HumanConnection>(request));
            return NoContent();
        }      

        // DELETE api/<ConnectedHumansController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (! await humanConnections.CheckAsync(x=>x.Id==id))
            {
                return NotFound();
            }
            await humanConnections.DeleteAsync(id);
            return NoContent();
        }
    }
}
