using System;
using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.Http;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/")]
    public class ApiEntryPointController : Controller, IApiEntryPointController
    {
        #region WebApi Methods
        
        /// <summary>
        /// API Root Path. Use this to see if the API is working.
        /// </summary>
        /// <returns>A pong</returns>
        /// <response code="200">Returns pong to let you know that it's working</response>
        [HttpGet]
        [Produces("application/vnd.api+json")]
        public Document Get()
        {
            var apiEntryPoint = new ApiEntryPoint
            {
                EntryPointId = Guid.NewGuid().ToString("N"),
                Message = @"pong"
            };

            var currentRequestUri = this.Request.GetUri();
            
            var scheme = currentRequestUri.Scheme;
            var host = currentRequestUri.Host;
            var port = currentRequestUri.Port;
            var urlBuilderConfiguration = new UrlBuilderConfiguration(scheme, host, port);


            var booksResourceCollectionLink = CreateBooksResourceCollectionLink(urlBuilderConfiguration);
            var authorsResourceCollectionLink = CreateAuthorsResourceCollectionLink(urlBuilderConfiguration);

            using (var documentContext = new ResponseDocumentContext(currentRequestUri))
            {
                var document = documentContext
                    .NewDocument(currentRequestUri)
                    .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                    .AddSelfLink()
                    .LinksEnd()
                    .Resource(apiEntryPoint)
                    .Links()
                    .AddLink("books",booksResourceCollectionLink)
                    .AddLink("authors",authorsResourceCollectionLink)
                    .LinksEnd()
                    .ResourceEnd()
                    .WriteDocument();

                return document;
            }
        }

        #endregion
        
        #region Private Methods
        private static Link CreateBooksResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var booksResourceCollectionUrl = UrlBuilder.Create(urlBuilderConfiguration)
                .Path("books")
                .Build();
            var bookResourceCollectionLink = new Link(booksResourceCollectionUrl);
            return bookResourceCollectionLink;
        }
        
        private static Link CreateAuthorsResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var authorsResourceCollectionUrl = UrlBuilder.Create(urlBuilderConfiguration)
                .Path("authors")
                .Build();
            var authorResourceCollectionUrl = new Link(authorsResourceCollectionUrl);
            return authorResourceCollectionUrl;
        }

        #endregion
    }
}