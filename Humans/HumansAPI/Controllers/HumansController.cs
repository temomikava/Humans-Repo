using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HumansAPI.Data;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using AutoMapper;
using HumansAPI.DTOs;

namespace HumansAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumansController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepository<Human> humans;
        private readonly IRepository<City> cities;
        private readonly IRepository<HumanConnection> connections;
        private readonly IRepository<Phone> phones;

        public HumansController(IMapper mapper, IRepository<Human> humans,IRepository<City> cities,
                                IRepository<HumanConnection> connections, IRepository<Phone> phones)
        {
            this.mapper = mapper;
            this.humans = humans;
            this.cities = cities;
            this.connections = connections;
            this.phones = phones;
        }

        // GET: api/Humans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadHumanRequest>>> GetHumans()
        {
            var result=await humans.ReadAsync();
            
            var readHumanDto = mapper.Map<IEnumerable<ReadHumanRequest>>(result);
            foreach (var human in readHumanDto)
            {
                var numbers = await phones.ReadAsync(x => x.HumanId == human.Id);
                var connectedHumans=await connections.ReadAsync(x=>x.FirstHumanId==human.Id || x.SecondHumanId==human.Id);
                human.Phones?.AddRange(mapper.Map<IEnumerable<ReadPhoneRequest>>(numbers));
                human.Connections?.AddRange(mapper.Map<IEnumerable<ReadConnectedHumanRequest>>(connectedHumans));
            }
            return Ok(readHumanDto);
        }

        // GET: api/Humans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadHumanRequest>> GetHuman(int id)
        {
            var human = await humans.ReadAsync(id);

            if (human == null)
            {
                return NotFound();
            }
            var humanDto=mapper.Map<ReadHumanRequest>(human);
            var numbers = await phones.ReadAsync(x => x.HumanId == human.Id);
            var connectedHumans = await connections.ReadAsync(x => x.FirstHumanId == human.Id || x.SecondHumanId == human.Id);
            humanDto.Phones?.AddRange(mapper.Map<IEnumerable<ReadPhoneRequest>>(numbers));
            humanDto.Connections?.AddRange(mapper.Map<IEnumerable<ReadConnectedHumanRequest>>(connectedHumans));
            return humanDto;
        }

        // PUT: api/Humans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutHuman(UpdateHumanRequest request)
        {
           
            await humans.UpdateAsync(request.Id, mapper.Map<Human>(request));
            return NoContent();
        }

        // POST: api/Humans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Human>> PostHuman(CreateHumanRequest request)
        {
            await  humans.CreateAsync(mapper.Map<Human>(request));
            return NoContent();
        }

        // DELETE: api/Humans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuman(int id)
        {
            if (! await humans.CheckAsync(x=>x.Id==id))
            {
                return NotFound();
            }
            await humans.DeleteAsync(id);                      
            return NoContent();
        }      
    }
}
