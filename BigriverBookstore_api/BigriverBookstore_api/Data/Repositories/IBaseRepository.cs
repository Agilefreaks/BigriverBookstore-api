using System.Collections.Generic;
using BigriverBookstore_api.Data.Entities;

namespace BigriverBookstore_api.Data.Repositories
{
    public interface IBaseRepository<Entity>
        where Entity : BaseEntity
    {
        List<Entity> GetAllEntities();

        Entity GetById(int id);

        void Add(Entity entity);

        void Delete(Entity entity);

        void ClearAll();

        void Save();
    }
}
