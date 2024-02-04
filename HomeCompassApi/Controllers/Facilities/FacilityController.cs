using AutoMapper;
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Facilities;
using HomeCompassApi.Services.Facilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace HomeCompassApi.Controllers.Facilities
{
    [ApiController]
    [Route("[controller]")]
    public class FacilityController : Controller
    {
        private readonly IRepository<Facility> _repository;
        private readonly IMapper _mapper;
        public FacilityController(IRepository<Facility> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(FacilityDto Dto)
        {
            if (Dto is null)
                return BadRequest();
            var Facility = _mapper.Map<Facility>(Dto);
            _repository.Add(Facility);
            return Ok("Added");
            //return CreatedAtAction(nameof(Get), new { Id = facility.Id }, facility);
        }

        [HttpGet]
        public ActionResult<List<FacilityDto>> Get()
        {
            var facilities = _repository.GetAll();
            var facilityDtos = _mapper.Map<IEnumerable<FacilityDto>>(facilities).ToList();
            return Ok(facilityDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<FacilityDto> GetById(int id)
        {
            var facility = _repository.GetById(id);
            if (facility is null)
                return NotFound();
            var facilityDto = _mapper.Map<FacilityDto>(facility);

            return Ok(facilityDto);
        }


        [HttpPut]
        public IActionResult Update(int id, FacilityDto Dto)
        {
            if (Dto is null)
                return BadRequest();
            var facilty = _repository.GetById(id);
            if (facilty is null)
                return NotFound();
            _mapper.Map(Dto, facilty);
            _repository.Update(facilty);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var facility = _repository.GetById(id);
            if (facility is null)
                return NotFound();

            if (id <= 0)
                return BadRequest();

            _repository.Delete(id);
            return Ok("Deleted");
        }
    }
}
