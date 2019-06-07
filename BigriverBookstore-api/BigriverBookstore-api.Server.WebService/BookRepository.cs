using System;
using System.Collections.Generic;
using System.Linq;

using BigriverBookstore_api.ServiceModel;


namespace BigriverBookstore_api.WebService
{
    public class BookRepository : IBookRepository
    {
        #region Public Methods

        public IEnumerable<Book> GetBooks()
        { return Books; }

        public IEnumerable<Photo> GetBookToPhotos(long bookId)
        {
            var bookToPhotos = Photos.Where(x => x.BookId == bookId)
                .ToList();
            return bookToPhotos;
        }

        #endregion

        #region Private Properties
        private static List<Book> Books { get; set; }
        private static List<Photo> Photos { get; set; }
        #endregion
        
        public BookRepository()
        {
            Books = new List<Book>
            {
                new Book()
                {
                    BookId = 1,
                    Title = "Domain-Driven Design",
                    DatePublished = DateTime.Today,
                    ISBN = "978-0321125217"

                },
                new Book()
                {
                    BookId = 2,
                    Title = "Sample 3",
                    DatePublished = DateTime.Today,
                    ISBN = "582-0322535753"

                },
                new Book()
                {
                    BookId = 3,
                    Title = "Sample 3",
                    DatePublished = DateTime.Today,
                    ISBN = "412-1437126362"

                }
                ,
                new Book()
                {
                    BookId = 4,
                    Title = "Sample 4",
                    DatePublished = DateTime.Today,
                    ISBN = "836-3712146362"

                }
            };

            Photos = new List<Photo>
            {
                new Photo
                {
                    BookId = 1,
                    PhotoId = 1,
                    PhotoUri = new Uri("https://placekitten.com/200/300")
                },
                new Photo
                {
                    BookId = 1,
                    PhotoId = 4,
                    PhotoUri = new Uri("https://placekitten.com/200/300")
                },
                new Photo
                {
                    BookId = 2,
                    PhotoId = 2,
                    PhotoUri = new Uri("https://placekitten.com/200/300")
                },
                new Photo
                {
                    BookId = 3,
                    PhotoId = 3,
                    PhotoUri = new Uri("https://placekitten.com/200/300")
                }
            };
        }
    }
}