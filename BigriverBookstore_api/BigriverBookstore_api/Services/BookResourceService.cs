using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Services;
using BigriverBookstore_api.Resources;
using JsonApiDotNetCore.Models;
using BigriverBookstore_api.Data;
using AutoMapper;

namespace BigriverBookstore_api.Services
{
    public class BookResourceService : BaseService, IResourceService<Book>
    {        
        public BookResourceService(IRepositoryWrapper wrapper, IMapper mapper) : base(wrapper, mapper){}

        public Task<Book> CreateAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAsync(int id)
        {
            var task = new Task<Book>(() => this.GetOne(id));

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }

        public Task<object> GetRelationshipAsync(int id, string relationshipName)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetRelationshipsAsync(int id, string relationshipName)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateAsync(int id, Book entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRelationshipsAsync(int id, string relationshipName, List<ResourceObject> relationships)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAsync()
        {
            var task = new Task<IEnumerable<Book>>(() => this.GetAll());

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }

        private IEnumerable<Book> GetAll()
        {
            var books = _wrapper.Books.GetAllEntities();
            return books.Select(b => _mapper.Map<Data.Entities.Book, Book>(b));
        }

        private Book GetOne(int id)
        {
            var book = _wrapper.Books.GetById(id);
            return _mapper.Map<Data.Entities.Book, Book>(book);
        }
        
    }
}
