using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;
using UrlShortener.Application.Contracts;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlRepository urlService;

        public UrlController(IUrlRepository repository)
        {
            urlService = repository;
        }

        [HttpGet("{id?}")]
        public IActionResult GetUrls(string? id)
        {
            var myTodos = urlService.AllUrls();

            if (id is null) return Ok(myTodos);

            myTodos = myTodos.Where(t => t.ID == Guid.Parse(id.ToString().ToUpper())).ToList();

            return Ok(myTodos);
        }

        [HttpPost]
        public IActionResult GetShortUrl(string longUrl, string headerLink)
        {
            if (longUrl is null) return BadRequest();

            string shortUrl = urlService.GetShortUrl(longUrl, headerLink);

            return Ok(shortUrl);
        }

        [HttpPost("GetLongUrl")]
        public IActionResult GetLongUrl(string? shortUrl)
        {
            if (shortUrl is null) return BadRequest();

            string longUrl = urlService.GetLongUrl(shortUrl);

            if (longUrl is null or "") return BadRequest();

            return Ok(longUrl);
        }
    }
}
