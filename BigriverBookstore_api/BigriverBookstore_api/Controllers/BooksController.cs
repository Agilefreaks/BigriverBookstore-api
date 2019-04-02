using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using BigriverBookstore_api.Models;

namespace BigriverBookstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : JsonApiController<Book>
    {
        public BooksController(IJsonApiContext jsonApiContext, IResourceService<Book> resourceService) : base(jsonApiContext, resourceService) { }
    }
}
