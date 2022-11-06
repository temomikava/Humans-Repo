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
    public class PhonesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepository<Human> humans;
        private readonly IRepository<Phone> phones;

        public PhonesController(IMapper mapper, IRepository<Human> humans,
                                 IRepository<Phone> phones)
        {
            this.mapper = mapper;
            this.humans = humans;
            this.phones = phones;
        }
      
        // GET api/<PhonesController>/5
        [HttpGet("{HumanId}")]
        public async Task<ActionResult<IEnumerable<ReadPhoneDTO>>> Get(int HumanId)
        {
            if (! await humans.CheckAsync(x=>x.Id==HumanId))
            {
                return NotFound();
            }
            var phonesInDb = phones.ReadAsync(x => x.HumanId == HumanId).Result;
            return Ok(mapper.Map<IEnumerable<ReadPhoneDTO>>(phonesInDb));
        }

        // POST api/<PhonesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPhoneRequest request)
        {
            await phones.CreateAsync(mapper.Map<Phone>(request));
            return NoContent();
        }

        // PUT api/<PhonesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePhoneRequest request)
        {
            var phone=mapper.Map<Phone>(request);
            await phones.UpdateAsync(phone);
            return NoContent();
        }

        // DELETE api/<PhonesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (! await phones.CheckAsync(x=>x.Id==id))
            {
                return NotFound();
            }
            await phones.DeleteAsync(id);
            return NoContent();
        }
    }
}
