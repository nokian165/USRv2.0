using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using USRv2.Models;
using USRv2.Dtos;

namespace USRv2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<NumericSamples, TrendDataDto>();
            Mapper.CreateMap<TrendDataDto, NumericSamples>();
        }
    }
}