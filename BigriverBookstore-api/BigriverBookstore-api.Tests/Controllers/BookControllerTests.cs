using BigriverBookstore_api.ServiceModel;
using BigriverBookstore_api.WebService.Controllers;
using JsonApiFramework.ServiceModel.Configuration;
using Moq;
using Xunit;

namespace BigriverBookstore_api.Tests.Controllers
{
    public class BookControllerTests : ResourceTypeBuilder<Book>
    {
        [Fact]
        public void GetBooks_Always_ReturnsSuccess()
        {
            // Arrange
            var mock = new Mock<IBookController>();

            // Assert
            var response = mock.Setup(r => r.GetBooks());
            
            Assert.NotNull(response);
        }
    }
}