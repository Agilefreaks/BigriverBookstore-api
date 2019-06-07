using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/books")]
    public class BookController : Controller, IBookController
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        #region WebApi Methods
        
        /// <summary>
        /// Books path. Use this to see all books from the list
        /// </summary>
        /// <returns>A couple of sample books</returns>
        /// <response code="200">Returns a couple of sample books to let you know that it's working</response>
        [HttpGet]
        [Produces("application/vnd.api+json")]
        public Document GetBooks()
        {
            var sampleBooks = _bookRepository.GetBooks();

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
                    .Relationships()
                    .AddRelationship("photos", new[] { Keywords.Related})
                    .AddRelationship("authors", new[] { Keywords.Related})
                    .RelationshipsEnd()
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