using AutoMapper;

namespace BigriverBookstore_api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Data.Entities.Book, Resources.Book>().ReverseMap();
            this.CreateMap<Data.Entities.Author, Resources.Author>().ReverseMap();
        }
    }
}
