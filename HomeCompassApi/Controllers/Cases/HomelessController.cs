using AutoMapper;
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Services.Cases;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeCompassApi.Controllers.Cases
{
    [ApiController]
    [Route("[controller]")]

    public class HomelessController : Controller
    {
        private readonly IRepository<Homeless> _repository;
        private readonly IMapper _mapper;
        public HomelessController(IRepository<Homeless> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var Homeless= _repository.GetAll();
           var result= _mapper.Map<IEnumerable<HomelessDTO>>(Homeless);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var homeless = _repository.GetById(id);
            if (homeless is null)
                return NotFound(); 
            var res = _mapper.Map<HomelessDTO>(homeless);           
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create(HomelessDTO homelessDto)
        {
            if (homelessDto is null)
                return BadRequest("Please provide the Homeless...");           
                var homeless = _mapper.Map<Homeless>(homelessDto);
                homeless.Archived = false;
                _repository.Add(homeless);
                //  return Ok("added ");
                return CreatedAtAction(nameof(Get), new { id = homeless.Id }, homeless);
         
        }

        [HttpPut]
        public IActionResult Update(int id,HomelessDTO homelessDto)
        {
            if (homelessDto is null)
                return BadRequest();

            var homelessDb = _repository.GetById(id);           
            if (homelessDb is null)
                return NotFound();

            
            _mapper.Map(homelessDto, homelessDb);

            _repository.Update(homelessDb);

            return Ok("updated ya negm Elnegoom");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var homeless = _repository.GetById(id);
            if (homeless is null)
                return NotFound();

            _repository.Delete(id);

            return Ok("deleted");
        }


    }
}
