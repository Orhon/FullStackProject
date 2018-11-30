using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eindproject2.Models
{
    public class PlansMappingProfile : Profile
    {
        public PlansMappingProfile()
        {
            CreateMap<Plans, PlansModel>()
                .ReverseMap(); //voorziet eenvoudige bidirectonele mapping
        }
    }
}
