using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;
using UrlShortener.Application.Urls;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlAppService _urlAppService;

        public UrlController(IUrlAppService appService)
        {
            _urlAppService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUrls()
        {
            var myTodos = await _urlAppService.GetListAsync();

            return Ok(myTodos);
        }

        [HttpPost("GetShortUrl")]
        public async Task<IActionResult> GetShortUrl(string longUrl, string headerLink)
        {
            if (longUrl is null) return BadRequest();

            var shortUrl = await _urlAppService.CreateAsync(new CreateUrlDto() { LongUrl = longUrl, HeaderLink = headerLink});

            return Ok(shortUrl);
        }

        //[HttpPost("GetLongUrl")]
        //public IActionResult GetLongUrl(string? shortUrl)
        //{
        //    if (shortUrl is null) return BadRequest();

        //    string longUrl = _urlAppService.GetLongUrl(shortUrl);

        //    if (longUrl is null or "") return BadRequest();

        //    return Ok(longUrl);
        //}
    }
}
