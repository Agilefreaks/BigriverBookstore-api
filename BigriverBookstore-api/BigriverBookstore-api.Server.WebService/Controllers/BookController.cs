using System;
using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/book/")]
    public class BookController : Controller
    {
        #region WebApi Methods
        
        /// <summary>
        /// Books path. Use this to see all books from the list
        /// </summary>
        /// <returns>A couple of sample books</returns>
        /// <response code="200">Returns a couple of sample books to let you know that it's working</response>
        [HttpGet]
        [Produces("application/vnd.api+json")]
        public Document Get()
        {
            var sampleBooks = new[]
            {
                new Book()
                {
                    BookId = 1,
                    Title = "Domain-Driven Design",
                    DatePublished = DateTime.Today,
                    ISBN = "978-0321125217"
                    
                },
                new Book()
                {
                BookId = 2,
                Title = "Sample 2",
                DatePublished = DateTime.Today,
                ISBN = "582-0322535753"
                    
                },
                new Book()
                {
                BookId = 3,
                Title = "Sample 3",
                DatePublished = DateTime.Today,
                ISBN = "412-1437126362"
                    
                }
            };

            var currentRequestUri = new Uri("http://localhost:5000");

            using (var documentContext = new ResponseDocumentContext(currentRequestUri))
            {
                var document = documentContext
                    .NewDocument(currentRequestUri)
                    .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                    .AddSelfLink()
                    .LinksEnd()
                    .ResourceCollection(sampleBooks)
                    .ResourceCollectionEnd()
                    .WriteDocument();

                return document;
            }
        }

        #endregion
    }
}