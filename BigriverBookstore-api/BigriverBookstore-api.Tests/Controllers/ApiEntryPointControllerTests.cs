using System;
using System.Net.Http;
using System.Text;
using BigriverBookstore_api.ServiceModel;
using BigriverBookstore_api.WebService.Controllers;
using JsonApiFramework.JsonApi;
using JsonApiFramework.ServiceModel.Configuration;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BigriverBookstore_api.Tests.Controllers
{
    public class ApiEntryPointControllerTests : ResourceTypeBuilder<ApiEntryPoint>
    {
        [Fact]
        public void Get_Always_ReturnsSuccess()
        {
            // Arrange
            var controller = new ApiEntryPointController();

            // Act
            Document response = controller.Get();

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public void Get_APIVersion_AsExpected()
        {
            var controller = new ApiEntryPointController();

            var response = controller.Get().JsonApiVersion.Version;
            
            Assert.Same("1.0", response);

        }
    }
}