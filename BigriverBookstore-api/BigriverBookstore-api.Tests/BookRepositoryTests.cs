using System;
using System.Collections.Generic;
using System.Linq;
using BigriverBookstore_api.ServiceModel;
using BigriverBookstore_api.WebService;
using JsonApiFramework.ServiceModel.Configuration;
using Moq;
using Xunit;

namespace BigriverBookstore_api.Tests
{
    public class BookRepositoryTests : ResourceTypeBuilder<IBookRepository>
    {
        [Fact]
        public void GetBooks_ShouldWork()
        {

            var mock = new Mock<IBookRepository>();
            
            // Arrange
            IList<Book> testBooks = new List<Book>
            {
                new Book
                {
                    BookId = 8,
                    DatePublished = DateTime.Today,
                    ISBN = "532786432",
                    Title = "Title"
                }
            };

            mock.Setup(x => x.GetBooks()).Returns(testBooks);
            
            Assert.Equal(testBooks, mock.Object.GetBooks());
        }
        
        [Fact]
        public void GetBookToPhotos_ShouldWork()
        {

            var mock = new Mock<IBookRepository>();
            
            // Arrange
            IList<Book> testBooks = new List<Book>
            {
                new Book
                {
                    BookId = 8,
                    DatePublished = DateTime.Today,
                    ISBN = "532786432",
                    Title = "Title"
                }
            };

            IList<Photo> testPhotos = new List<Photo>
            {
                new Photo
                {
                    BookId = 8,
                    PhotoId = 2,
                    PhotoUri = new Uri("https://localhost:5000/books")
                }
            };

            var response = mock.Setup(x => x.GetBookToPhotos(testBooks.First().BookId)).Returns(testPhotos);
            
            Assert.NotNull(response);
        }
    }
}