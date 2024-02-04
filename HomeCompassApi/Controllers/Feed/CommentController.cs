using AutoMapper;
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Services.Feed;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Reflection;

namespace HomeCompassApi.Controllers.Feed
{
    [ApiController]
    //[Route(("posts/{postId}/comments"))]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;
        public CommentController(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create(CommentDto commentDto)
        {
            if (commentDto is null)
                return BadRequest();
            var comment = _mapper.Map<Comment>(commentDto);
            _repository.Add(comment);
             return Ok("added");
             //return CreatedAtAction(nameof(Get), new { Id = comment.Id }, comment);
        }

        [HttpGet]
        // this is to get comments of Spesific Post
        public ActionResult<List<CommentDto>> GetForPost(int postId)
        {
            var comments = _repository.GetAll().Where(x => x.PostId == postId);
            var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return Ok(commentsDto);
        }


        [HttpGet("{id}")]
        public ActionResult<CommentDto> GetById(int id)
        {
            if (id <= 0) return BadRequest();
            var comment = _repository.GetById(id);
            if (comment == null)
                return NotFound();
            var Commentdto = _mapper.Map<CommentDto>(comment);

            return Ok(Commentdto);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = _repository.GetById(id);
            if (comment is null)
                return NotFound();

            _repository.Delete(id);
            return Ok("Deleted");
        }

        [HttpPut] // ("{id}")
        public IActionResult Update(int id, CommentDto Dto)
        {
            var comment = _repository.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }
            _mapper.Map(Dto, comment);

            _repository.Update(comment);
            return Ok("Updated");

        }

    }
}
