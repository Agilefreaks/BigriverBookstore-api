using System;
using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/books")]
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
            var sampleBooks = BookRepository.GetBooks();

            var currentRequestUri = this.Request.GetUri();

            using (var documentContext = new ResponseDocumentContext(currentRequestUri))
            {
                var document = documentContext
                    .NewDocument(currentRequestUri)
                    .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                    .AddSelfLink()
                    .LinksEnd()
                    .ResourceCollection(sampleBooks)
                    .Links()
                    .AddSelfLink()
                    .LinksEnd()
                    .ResourceCollectionEnd()
                    .WriteDocument();

                return document;
            }
        }

        #endregion
    }
}