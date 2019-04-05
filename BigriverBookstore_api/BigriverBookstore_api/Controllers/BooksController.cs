using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using BigriverBookstore_api.Resources;

namespace BigriverBookstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : JsonApiController<Book>
    {
        public BooksController(IJsonApiContext jsonApiContext, IResourceService<Book> resourceService) : base(jsonApiContext, resourceService) { }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        => await base.GetAsync();

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
            => await base.GetAsync(id);
    }
}
