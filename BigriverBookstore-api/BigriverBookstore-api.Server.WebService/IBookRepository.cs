using System.Collections.Generic;
using BigriverBookstore_api.ServiceModel;

namespace BigriverBookstore_api.WebService
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();

        IEnumerable<Photo> GetBookToPhotos(long bookId);

    }
}