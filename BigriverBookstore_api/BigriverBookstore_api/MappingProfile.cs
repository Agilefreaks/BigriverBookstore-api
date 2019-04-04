using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigriverBookstore_api.Resources;
using BigriverBookstore_api.Data.Entities;
using AutoMapper;

namespace BigriverBookstore_api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Data.Entities.Book, Resources.Book>().ReverseMap();
        }
    }
}
