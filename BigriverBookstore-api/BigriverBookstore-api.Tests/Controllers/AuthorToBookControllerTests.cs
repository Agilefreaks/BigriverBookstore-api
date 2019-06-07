using System;
using System.Collections.Generic;
using System.Linq;
using BigriverBookstore_api.ServiceModel;
using BigriverBookstore_api.WebService.Controllers;
using JsonApiFramework.ServiceModel.Configuration;
using Moq;
using Xunit;

namespace BigriverBookstore_api.Tests.Controllers
{
    public class AuthorToBookControllerTests : ResourceTypeBuilder<IAuthorToBooksController>
    {
        [Fact]
        public void GetAuthorToBooks_Always_ReturnsSuccess()
        {
            // Arrange\
            var mock = new Mock<IAuthorToBooksController>();
            
            IList<Author> testAuthors = new List<Author>
            {
                new Author
                {
                    AuthorId = 1,
                    FirstName = "AA",
                    LastName = "BB"
                }
            };

            var response = mock.Setup(r => r.GetAuthorToBooks(testAuthors.First().AuthorId));
            
            Assert.NotNull(response);
        }
    }
}