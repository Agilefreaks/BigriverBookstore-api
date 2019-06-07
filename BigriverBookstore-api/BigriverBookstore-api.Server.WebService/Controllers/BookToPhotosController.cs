using System;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/books/{id}/photos")]
    public class BookToPhotosController : Controller, IBookToPhotosController
    {
        
        private IBookRepository _bookRepository;

        public BookToPhotosController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        #region WebApi Methods
        /// <summary>
        /// Photos to Book path. Use this to see the list of photos used by a book
        /// </summary>
        /// <returns>List of photos of a book</returns>
        /// <response code="200">Returns a list of photos of a book to let you know that it's working</response>
        [HttpGet]
        [Produces("application/vnd.api+json")]
        public Document GetBookToPhotos(long id)
        {
            var bookToPhotos = _bookRepository.GetBookToPhotos(Convert.ToInt64(id));

            var currentRequestUri = this.Request.GetUri();
            using (var documentContext = new ResponseDocumentContext(currentRequestUri))
            {
                var document = documentContext
                    .NewDocument(currentRequestUri)
                    .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                    .AddSelfLink()
                    .LinksEnd()
                    .ResourceCollection(bookToPhotos)
                    .Relationships()
                    .AddRelationship("books", new[] { Keywords.Related })
                    .RelationshipsEnd()
                    .ResourceCollectionEnd()
                    .WriteDocument();

                return document;
            }
        }

        #endregion
    }
}