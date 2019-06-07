using BigriverBookstore_api.ServiceModel;
using BigriverBookstore_api.WebService.Controllers;
using JsonApiFramework.ServiceModel.Configuration;
using Moq;
using Xunit;

namespace BigriverBookstore_api.Tests.Controllers
{
    public class AuthorControllerTests : ResourceTypeBuilder<Author>
    {
        [Fact]
        public void GetAuthors_Always_ReturnsSuccess()
        {
            // Arrange
            var mock = new Mock<IAuthorController>();

            // Assert
            var response = mock.Setup(r => r.GetAuthor());
            
            Assert.NotNull(response);
        }
    }
}