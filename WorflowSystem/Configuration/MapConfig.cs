using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worflow.Models;
using Worflow.Models.Dtos;

namespace Worflow.Configuration
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<Lead, LeadDto>().ReverseMap();
        }
    }
}
