using AutoMapper;
using MyShopsAPI.Controllers.Resources;
using MyShopsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopsAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FeedbackResource, Feedback>()
                .ForMember(f=>f.Id, opt=>opt.Ignore());
            CreateMap<StoreSaveResources, Store>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Feedback, FeedbackResource>();
            CreateMap<Store, StoreSaveResources>();
        }
    }
}
