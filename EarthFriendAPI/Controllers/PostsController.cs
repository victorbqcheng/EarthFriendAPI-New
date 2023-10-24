using EarthFriendAPI.Models;
using EarthFriendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EarthFriendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController:ControllerBase
    {
        private readonly PostsService _postsService;
        public PostsController(PostsService postsService)=>
            _postsService = postsService;

        [HttpGet]
        public async Task<List<Post>> Get()
        {
            return await _postsService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Post>> Get(string id)
        { 
            var post = await _postsService.GetAsync(id);
            if (post is null) {
                return NotFound();
            }
            return post;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post newPost)
        {
            await _postsService.CreateAsync(newPost);
            return CreatedAtAction(nameof(Post), new { id=newPost.Id}, newPost);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Post updatedPost)
        {
            var post = await _postsService.GetAsync(id);
            if (post is null)
            {
                return NotFound();
            }
            updatedPost.Id = post.Id;
            await _postsService.UpdateAsync(id, updatedPost);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var post = _postsService.GetAsync(id);
            if (post is null)
            {
                return NotFound();
            }
            await _postsService.RemoveAsync(id);
            return NoContent();
        }
    }
}
