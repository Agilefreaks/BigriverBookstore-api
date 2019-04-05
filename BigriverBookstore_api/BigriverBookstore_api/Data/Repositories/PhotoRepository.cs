using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigriverBookstore_api.Data.Entities;

namespace BigriverBookstore_api.Data.Repositories
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository() : base() { }
    }
}
