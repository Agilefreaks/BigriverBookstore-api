using BigriverBookstore_api.Data.Entities;

namespace BigriverBookstore_api.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository() : base() { }
    }
}
