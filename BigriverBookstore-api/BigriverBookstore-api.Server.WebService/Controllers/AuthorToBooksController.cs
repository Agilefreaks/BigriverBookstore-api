using System;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/authors/{id}/books")]
    public class AuthorToBooksController : Controller, IAuthorToBooksController
    {
        private IBookRepository _bookRepository;

        public AuthorToBooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        #region WebApi Methods
        
        /// <summary>
        /// Author to Books path. Use this to see all the books of an author
        /// </summary>
        /// <returns>A couple of sample books of an author</returns>
        /// <response code="200">Returns a couple of sample books of an author to let you know that it's working</response>
        [HttpGet]
        [Produces("application/vnd.api+json")]
        public Document GetAuthorToBooks(long id)
        {
            var authorToBooks = _bookRepository.GetAuthorToBooks(Convert.ToInt64(id));

            var currentRequestUri = this.Request.GetUri();
            using (var documentContext = new ResponseDocumentContext(currentRequestUri))
            {
                var document = documentContext
                    .NewDocument(currentRequestUri)
                    .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                    .AddSelfLink()
                    .LinksEnd()
                    .ResourceCollection(authorToBooks)
                    .Relationships()
                    .AddRelationship("authors", new[] { Keywords.Related })
                    .RelationshipsEnd()
                    .ResourceCollectionEnd()
                    .WriteDocument();

                return document;
            }
        }

        #endregion
    }
}