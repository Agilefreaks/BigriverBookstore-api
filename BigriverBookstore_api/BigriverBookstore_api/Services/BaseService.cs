using AutoMapper;
using BigriverBookstore_api.Data;

namespace BigriverBookstore_api.Services
{
    public class BaseService
    {
        public IMapper _mapper { get; set; }

        public IRepositoryWrapper _wrapper;

        public BaseService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            this._wrapper = wrapper;
            this._mapper = mapper;
        }
    }
}
