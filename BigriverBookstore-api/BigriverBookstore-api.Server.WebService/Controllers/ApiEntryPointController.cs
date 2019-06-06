using System;
using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    [Route("/")]
    public class ApiEntryPointController : Controller
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

            var currentRequestUri = new Uri("http://localhost:5000");

            using (var documentContext = new ResponseDocumentContext(currentRequestUri))
            {
                var document = documentContext
                    .NewDocument(currentRequestUri)
                    .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                    .AddSelfLink()
                    .LinksEnd()
                    .Resource(apiEntryPoint)
                    .ResourceEnd()
                    .WriteDocument();

                return document;
            }
        }

        #endregion
    }
}