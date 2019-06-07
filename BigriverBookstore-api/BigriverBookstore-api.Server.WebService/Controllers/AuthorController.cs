using System;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/authors")]
    public class AuthorController : Controller, IAuthorController
    {
        private IBookRepository _bookRepository;

        public AuthorController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        #region WebApi Methods
        
        /// <summary>
        /// Authors path. Use this to see all authors from the list
        /// </summary>
        /// <returns>A couple of sample authors</returns>
        /// <response code="200">Returns a couple of sample authors to let you know that it's working</response>
        [HttpGet]
        [Produces("application/vnd.api+json")]
        public Document GetAuthor()
        {
            var authorToBooks = _bookRepository.GetAuthors();

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
                    .AddRelationship("books", new[] { Keywords.Related})
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