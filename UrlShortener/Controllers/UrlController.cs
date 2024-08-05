using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Business;

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
        public IActionResult GetTodos(Guid? id)
        {
            var myTodos = urlService.AllUrls();

            if (id is null) return Ok(myTodos);

            myTodos = myTodos.Where(t => t.ID == id).ToList();

            return Ok(myTodos);
        }
    }
}
