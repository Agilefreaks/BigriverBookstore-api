using System;
using System.Security.Policy;
using BigriverBookstore_api.ServiceModel;

using JsonApiFramework.Http;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BigriverBookstore_api.WebService.Controllers
{
    public class ApiEntryPointController : Controller
    {
        #region WebApi Methods

        [HttpGet("")]
        public Document GetAsync()
        {
            var apiEntryPoint = new ApiEntryPoint()
            {
                Message = @"pong",
            };

            var currentRequestUri = this.Request.GetUri();

            //var scheme = currentRequestUri.Scheme;
            //var host = currentRequestUri.Host;
            //var port = currentRequestUri.Port;
            //var urlBuilderConfiguration = new UrlBuilderConfiguration(scheme, host, port);
            
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