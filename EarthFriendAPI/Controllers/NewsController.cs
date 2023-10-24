using EarthFriendAPI.Models;
using EarthFriendAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EarthFriendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _newsService;
        public NewsController(NewsService newsService) =>
            _newsService = newsService;

        [HttpGet]
        public async Task<List<News>> Get()
        {
            return await _newsService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<News>> Get(string id)
        {
            var news = await _newsService.GetAsync(id);
            if (news is null)
            {
                return NotFound();
            }
            return news;
        }
    }
}
