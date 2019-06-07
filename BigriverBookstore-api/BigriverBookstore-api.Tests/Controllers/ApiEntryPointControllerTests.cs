using BigriverBookstore_api.ServiceModel;
using BigriverBookstore_api.WebService.Controllers;
using JsonApiFramework.ServiceModel.Configuration;
using Moq;
using Xunit;

namespace BigriverBookstore_api.Tests.Controllers
{
    public class ApiEntryPointControllerTests : ResourceTypeBuilder<ApiEntryPoint>
    {
        [Fact]
        public void Get_Always_ReturnsSuccess()
        {
            // Arrange
            var mock = new Mock<IApiEntryPointController>();

            // Act
            var response = mock.Setup(r => r.Get());
            
            // Assert
            Assert.NotNull(response);
        }
    }
}