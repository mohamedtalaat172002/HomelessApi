using AutoMapper;
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Facilities;
using HomeCompassApi.Services.Facilities;
using Microsoft.AspNetCore.Mvc;

namespace HomeCompassApi.Controllers.Facilities
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : Controller
    {
        private readonly IRepository<Resource> _repository;
        private readonly IMapper _mapper;

        public ResourceController(IRepository<Resource> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Create(ResourceDto Dto)
        {
            if (Dto is null)
                return BadRequest();
            var resource = _mapper.Map<Resource>(Dto);
            _repository.Add(resource);
            return CreatedAtAction(nameof(Get), new { Id = resource.Id }, resource);
        }


        [HttpGet]
        public ActionResult<List<ResourceDto>> Get()
        {
            var resources = _repository.GetAll();
            var resorcesDto = _mapper.Map<IEnumerable<ResourceDto>>(resources).ToList();
            return Ok(resorcesDto);
        }


        [HttpGet("{id}")]
        public ActionResult<ResourceDto> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var resource = _repository.GetById(id);

            if (resource is null)
                return NotFound();
            var resourceDto = _mapper.Map<ResourceDto>(resource);

            return Ok(resourceDto);
        }

        [HttpPut]
        public IActionResult Update(int id, ResourceDto Dto)
        {
            if (Dto is null)
                return BadRequest();

            var resource = _repository.GetById(id);
            if (resource is null)
                return NotFound();
            _mapper.Map(Dto, resource);
            _repository.Update(resource);

            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (_repository.GetById(id) is null)
                return NotFound();

            _repository.Delete(id);

            return Ok("Deleted");
        }
    }
}
