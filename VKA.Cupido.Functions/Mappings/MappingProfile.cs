using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            CreateMap<EmailEntity, EmailModel>();
            CreateMap<EmailModel, EmailEntity>();
        }
    }
}
