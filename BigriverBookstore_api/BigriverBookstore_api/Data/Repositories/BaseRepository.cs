using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigriverBookstore_api.Data.Entities;

namespace BigriverBookstore_api.Data.Repositories
{
    public abstract class BaseRepository<Entity> where Entity : BaseEntity
    {
        public List<Entity> _repository;

        public BaseRepository()
        {
            _repository = new List<Entity>();
        }
        
        public List<Entity> GetAllEntities()
        {
            return this._repository;
        }

        public Entity GetById(int id)
        {
            return this._repository.Single(e => e.Id == id);
        }

        public void Add(Entity entity)
        {
            this._repository.Add(entity);
        }

        public void Delete(Entity entity)
        {
            this._repository.Remove(entity);
        }

        public void ClearAll()
        {
            this._repository.Clear();
        }
        
        public void Save()
        {
            // TBI
        }
    }
}
