using BigriverBookstore_api.Data.Repositories;

namespace BigriverBookstore_api.Data
{
    public interface IRepositoryWrapper
    {
        IBookRepository BookRepository { get; }

        IAuthorRepository AuthorRepository { get; }
    }
}
