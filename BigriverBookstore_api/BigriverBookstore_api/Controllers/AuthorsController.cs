using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using BigriverBookstore_api.Resources;
using BigriverBookstore_api.Data;

namespace BigriverBookstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : JsonApiController<Author>
    {
        public AuthorsController(IJsonApiContext jsonApiContext, IResourceService<Author> resourceService) : base(jsonApiContext, resourceService) { }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        => await base.GetAsync();

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
            => await base.GetAsync(id);
    }
}
