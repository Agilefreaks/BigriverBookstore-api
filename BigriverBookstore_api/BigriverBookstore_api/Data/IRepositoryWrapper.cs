using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigriverBookstore_api.Data.Repositories;

namespace BigriverBookstore_api.Data
{
    public interface IRepositoryWrapper
    {
        IBookRepository BookRepository { get; }

        IAuthorRepository AuthorRepository { get; }
    }
}
