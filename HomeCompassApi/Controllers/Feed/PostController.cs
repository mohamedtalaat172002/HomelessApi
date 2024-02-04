using AutoMapper;
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Services.Feed;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HomeCompassApi.Controllers.Feed
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;
        public PostController(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        //All Posts to be represented in Home
        public ActionResult<List<PostDto>> Get()
        {
            var posts = _repository.GetAll().ToList();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postsDto);

        }

        [HttpGet("{userid}")]
        public ActionResult<List<PostDto>> GetPostsForSpecificUser(string userid)
        {
            var posts = _repository.GetAll().Where(p => p.UserId == userid);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postsDto);

        }

        [HttpGet("{id}")]
        public ActionResult<PostDto> GetById(int id)
        {
            var post = _repository.GetById(id);
            if (post is null)
                return NotFound(id);

            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpPost]
        public IActionResult Create(PostDto Dto)
        {
            if (Dto is null)
                return BadRequest();
            var post = _mapper.Map<Post>(Dto);
            _repository.Add(post);
            return Ok("Added");

        }

        [HttpPut]
        public IActionResult Update(int id, PostDto Dto)
        {
            var existingcomment = _repository.GetById(id);

            if (existingcomment == null)
            {
                return NotFound();
            }
            _mapper.Map(Dto, existingcomment);

            _repository.Update(existingcomment);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _repository.GetById(id);
            if (post is null)
                return NotFound(id);


            _repository.Delete(id);
            return Ok("Deleted");
        }
    }
}
