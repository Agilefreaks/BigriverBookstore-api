using System;
using System.Collections.Generic;
using System.Linq;

using BigriverBookstore_api.ServiceModel;


namespace BigriverBookstore_api.WebService
{

    public static class BookRepository
    {
        #region Public Methods

        public static IEnumerable<Book> GetBooks()
        { return Books; }

        public static Book GetBook(long bookId)
        {
            var book = Books.Single(x => x.BookId == bookId);
            return book;
        }

        #endregion

        #region Private Properties
        private static List<Book> Books { get; set; }
        
        #endregion
        

        #region Static Constructor
        static BookRepository()
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
                    Title = "Sample 2",
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

        }
        #endregion
    }
}