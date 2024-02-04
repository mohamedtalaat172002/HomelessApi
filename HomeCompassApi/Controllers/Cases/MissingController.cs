using AutoMapper;
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Services.Cases;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace HomeCompassApi.Controllers.Cases
{
    [ApiController]
    [Route("[controller]")]
    public class MissingController : Controller
    {
        private readonly IRepository<Missing> _repository;
        private readonly IMapper _mapper;

        public MissingController(IRepository<Missing> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(MissingDTO missingDto)
        {
            if (missingDto is null)
                return BadRequest();
            var missing= _mapper.Map<Missing>(missingDto);
            _repository.Add(missing);
            missing.Archived = false;
          return Ok($"the {missing.FullName} added succefully to data base");
            //return CreatedAtAction(nameof(Get), new { Id = missing.Id }, missing);
        }

        [HttpGet]
        public ActionResult<List<MissingDTO>> Get()
        {
            var missing = _repository.GetAll();
            var missingDto= _mapper.Map<IEnumerable<MissingDTO>>(missing);
            return Ok(missingDto);
        }

        [HttpGet("{id}")]
        public ActionResult<MissingDTO> Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            var missing = _repository.GetById(id);
            if (missing is null)
                return NotFound();
            var missingDto = _mapper.Map<MissingDTO>(missing);
          
            return Ok(missingDto);
        }


        [HttpPut]
        public IActionResult Update(int id,MissingDTO missingDto)
        {
            if (missingDto is null ||id <= 0)
                return BadRequest();
           
           
            var missing= _repository.GetById(id);           
            if (missing is null)
                return NotFound();

          
            _mapper.Map(missingDto, missing);
            _repository.Update(missing);

            return Ok($"missing with name {missing.FullName} Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var missing = _repository.GetById(id);
            if (missing is null)
                return NotFound();

            _repository.Delete(id);
            return Ok("Deleted");
        }
    }
}
