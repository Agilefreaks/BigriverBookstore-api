using AutoMapper;
using BigriverBookstore_api.Data;

namespace BigriverBookstore_api.Services
{
    public abstract class BaseService
    {
        protected IMapper _mapper { get; set; }

        protected IRepositoryWrapper _wrapper;

        public BaseService(IRepositoryWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;
        }
    }
}
