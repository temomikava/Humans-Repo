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
using HumansAPI.Requests;
using HumansAPI.Enums;
using HumansAPI.Common;

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
        private readonly IImageService imageService;

        public HumansController(IMapper mapper, IRepository<Human> humans,IRepository<City> cities,
                                IRepository<HumanConnection> connections, IRepository<Phone> phones,
                               IImageService imageService)
        {
            this.mapper = mapper;
            this.humans = humans;
            this.cities = cities;
            this.connections = connections;
            this.phones = phones;
            this.imageService = imageService;
        }

        // GET: api/Humans
        [HttpGet("GetAllHuman")]
        public async Task<ActionResult<IEnumerable<ReadHumanDTO>>> GetHumans([FromQuery] GetAllHumanRequest request)
        {
            var result = await humans.ReadAsync();
            var filteredResult = result.Where(x =>
                 (request.PersonalNo == null || x.PersonalNumber.Contains(request.PersonalNo)) &&
                 (request.FirstName == null || x.FirstName.Contains(request.FirstName)) &&
                 (request.LastName == null || x.LastName.Contains(request.LastName)));
            var pageSize = (float)request.PageSize;
            var pageCount = Math.Ceiling(filteredResult.Count() / pageSize);
            var product = filteredResult.Skip((request.PageIndex - 1) * (int)pageSize).Take((int)pageSize);
            var readHumanDto = mapper.Map<IEnumerable<ReadHumanDTO>>(product);
            foreach (var human in readHumanDto)
            {
                var numbers = await phones.ReadAsync(x => x.HumanId == human.Id);
                var connectedHumans=await connections.ReadAsync(x=>x.FirstHumanId==human.Id || x.SecondHumanId==human.Id);
                var city=await cities.ReadAsync(human.City.Id);

                human.Phones?.AddRange(mapper.Map<IEnumerable<ReadPhoneDTO>>(numbers));
                human.Connections?.AddRange(mapper.Map<IEnumerable<ReadConnectedHumanDTO>>(connectedHumans));
                human.City=mapper.Map<ReadCityDTO>(city);
            }
            return Ok(new Response
            {
                PageIndex=request.PageIndex,
                TotalPages=(int)pageCount,
                PageSize=request.PageSize,
                Items=readHumanDto
            }) ;
        }

        // GET: api/Humans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadHumanDTO>> GetHuman(int id)
        {
            var human =await  humans.ReadAsync(id);

            if (human == null)
            {
                return NotFound();
            }
            var humanDto=mapper.Map<ReadHumanDTO>(human);

            var numbers = await phones.ReadAsync(x => x.HumanId == human.Id);
            var connectedHumans = await connections.ReadAsync(x => x.FirstHumanId == human.Id || x.SecondHumanId == human.Id);
            var city = await cities.ReadAsync(humanDto.City.Id);

            humanDto.Phones?.AddRange(mapper.Map<IEnumerable<ReadPhoneDTO>>(numbers));
            humanDto.Connections?.AddRange(mapper.Map<IEnumerable<ReadConnectedHumanDTO>>(connectedHumans));
            humanDto.City = mapper.Map<ReadCityDTO>(city);

            return Ok(humanDto);
        }

        [HttpPut("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest request)
        {
            var human =await humans.ReadAsync(request.HumanId);
            if (human==null)
            {
                return NotFound();
            }
            human.PhotoPath = await imageService.UploadImage(request.Image);
            await humans.UpdateAsync(human);
            return NoContent();
        }
        // PUT: api/Humans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutHuman(UpdateHumanRequest request)
        {
            var human = await humans.ReadAsync(request.Id);
            if (human is null)
            {
                return NotFound();
            }
            var humanByPersonalNumber = await humans.ReadAsync(x => x.PersonalNumber == request.PersonalNumber);
            if (humanByPersonalNumber.Count()!=0 && human.Id != humanByPersonalNumber.Single().Id) 
            {
                return BadRequest("ადამიანი იგივერ პირადი ნომრით უკვე დარეგისტრირებულია");
            }
            await humans.UpdateAsync(request.Id, mapper.Map<Human>(request));
            return NoContent();
        }

        // POST: api/Humans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Human>> PostHuman(AddHumanRequest request)
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
