using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogManager.Data;
using BlogManager.Models;
using BlogManager.DTOs;
using AutoMapper;

namespace BlogManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public PostsController(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return _mapper.Map<List<PostDTO>>(posts);
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();
            return Ok(_mapper.Map<PostDTO>(post));
        }

        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(CreatePostDTO createPostDTO)
        {
            var post = _mapper.Map<Post>(createPostDTO);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            var postDTO = _mapper.Map<PostDTO>(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, postDTO);
        }

        // PUT: api/posts/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] UpdatePostDTO newPost)
        {
            var oldPost = await _context.Posts.FindAsync(id);
            if (oldPost == null) return NotFound();

            _mapper.Map(newPost, oldPost);
            await _context.SaveChangesAsync();

            return Ok(oldPost);
        }

        // DELETE: api/posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
