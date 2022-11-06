using AutoMapper;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using HumansAPI.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HumansAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepository<City> cities;

        public CityController(IMapper mapper, IRepository<City> cities)
        {
            this.mapper = mapper;
            this.cities = cities;
        }
        // GET: api/<CityController>
        [HttpGet]
        public async Task<IEnumerable<ReadCityDTO>> Get()
        {
            return  mapper.Map<IEnumerable<ReadCityDTO>>(await cities.ReadAsync());
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCityDTO>> Get(int id)
        {
            var city=await cities.ReadAsync(id);
            if (city==null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ReadCityDTO>(city));
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCityRequest  request)
        {
            await cities.CreateAsync(mapper.Map<City>(request));
            return Ok();
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCityRequest request)
        {
            if (! await cities.CheckAsync(x=>x.Id==id))
            {
                return NotFound();
            }
            var city = mapper.Map<City>(request);
            city.Id = id;
            await cities.UpdateAsync(city);
            return NoContent();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (! await cities.CheckAsync(x=>x.Id==id))
            {
                return NotFound();
            }
            await cities.DeleteAsync(id);
            return NoContent();
        }
    }
}
