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
    public class AuthorResourceService : BaseService, IResourceService<Author>
    {        
        public AuthorResourceService(IRepositoryWrapper wrapper, IMapper mapper) : base(wrapper, mapper){}

        public Task<Author> CreateAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAsync(int id)
        {
            var task = new Task<Author>(() => this.GetOne(id));

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

        public Task<Author> UpdateAsync(int id, Author entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRelationshipsAsync(int id, string relationshipName, List<ResourceObject> relationships)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAsync()
        {
            var task = new Task<IEnumerable<Author>>(() => this.GetAll());

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }

        private IEnumerable<Author> GetAll()
        {
            var authors = _wrapper.AuthorRepository.GetAllEntities();
            return authors.Select(b => _mapper.Map<Data.Entities.Author, Author>(b));
        }

        private Author GetOne(int id)
        {
            var author = _wrapper.AuthorRepository.GetById(id);
            return _mapper.Map<Data.Entities.Author, Author>(author);
        }
        
    }
}
