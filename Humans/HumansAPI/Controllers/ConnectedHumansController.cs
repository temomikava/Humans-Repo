using AutoMapper;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Report;
using HumansAPI.Repositories;
using HumansAPI.Requests;
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

        [HttpGet("Report")]
        public async Task<List<Relation>> Get()
        {
            var connectedHumans = await humanConnections.ReadAsync();
            var allHumans = await humans.ReadAsync();
            
            var report = allHumans.OrderBy(x => x.Id).Select(human =>
            {
                var relatedConnections = connectedHumans.Where(x => x.FirstHumanId == human.Id || x.SecondHumanId == human.Id);                   
                var groupedRelatedConnections = relatedConnections.GroupBy(x => x.Type);
                var connections = groupedRelatedConnections.Select(x => new Connection(x.Count(), x.Key)).ToList();
                return new Relation(human.Id, connections);
            });
            return report.ToList();          
        }
                  
        [HttpGet("{humanId}/{connectionType}")]
        public async Task<ActionResult<IEnumerable<ReadConnectedHumanDTO>>> Get([FromRoute]int humanId,[FromRoute] int connectionType)
        {
            if (!await humans.CheckAsync(x => x.Id == humanId))
            {
                return NotFound();
            }
            var connections = await humanConnections.ReadAsync(x => (x.FirstHumanId == humanId || x.SecondHumanId == humanId) && 
                                                                    (int)x.Type == connectionType);
            return Ok(mapper.Map<IEnumerable<ReadConnectedHumanDTO>>(connections));
        }

        [HttpGet("{humanId}")]
        public async Task<ActionResult<IEnumerable<ReadConnectedHumanDTO>>> Get([FromRoute]int humanId)
        {
            if (! await humans.CheckAsync(x=>x.Id==humanId))
            {
                return NotFound();                    
            }
            var connections =await humanConnections.ReadAsync(x => x.FirstHumanId == humanId || x.SecondHumanId == humanId);
            return Ok(mapper.Map<IEnumerable<ReadConnectedHumanDTO>>(connections));
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
