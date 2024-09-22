using AutoMapper;
using VKA.Cupido.Entities;
using VKA.Cupido.Models;

namespace VKA.Cupido.Functions.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonModel, PersonEntity>();
            CreateMap<PersonEntity, PersonModel>();

            CreateMap<PairEntity, PairModel>();
            CreateMap<PairModel, PairEntity>();
        }
    }
}
