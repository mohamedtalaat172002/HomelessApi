using AutoMapper;
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Facilities;
using HomeCompassApi.Services.Cases;
using HomeCompassApi.Services.Facilities;
using Microsoft.AspNetCore.Mvc;

namespace HomeCompassApi.Controllers.Facilities
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryController(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CategoryDto dto)
        {
            if (dto is null)
                return BadRequest();
            var category = _mapper.Map<Category>(dto);
            _repository.Add(category);
            return Ok("added");
            //  return CreatedAtAction(nameof(Get), new { Id = category.Id }, category);
        }

        [HttpGet]
        public ActionResult<List<CategoryDto>> Get()
        {
            var Categories = _repository.GetAll();
            var CategoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(Categories).ToList();
            return Ok(CategoriesDto);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var category = _repository.GetById(id);

            if (category is null)
                return NotFound();
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPut]
        public IActionResult Update(int id, CategoryDto Dto)
        {
            if (Dto is null)
                return BadRequest();
            var category = _repository.GetById(id);
            if (category is null)
                return NotFound();
            _mapper.Map(Dto, category);
            _repository.Update(category);
            return Ok("Updated");
            //   return NoContent();
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
            //  return NoContent();
        }
    }
}
