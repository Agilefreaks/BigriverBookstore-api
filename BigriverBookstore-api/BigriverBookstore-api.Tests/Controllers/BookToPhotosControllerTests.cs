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
    public class BookToPhotosControllerTests : ResourceTypeBuilder<Photo>
    {
        
        [Fact]
        public void GetBookToPhotos_Always_ReturnsSuccess()
        {
            // Arrange\
            var mock = new Mock<IBookToPhotosController>();
            
            IList<Book> testBooks = new List<Book>
            {
                new Book
                {
                    BookId = 1,
                    DatePublished = DateTime.Today,
                    ISBN = "532786432",
                    Title = "Title"
                }
            };

            var response = mock.Setup(r => r.GetBookToPhotos(testBooks.First().BookId));
            
            Assert.NotNull(response);
        }
    }
}