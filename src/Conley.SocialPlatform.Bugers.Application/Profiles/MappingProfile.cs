using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Conley.SocialPlatform.Bugers.Application.Dtos;
using Conley.SocialPlatform.Bugers.Application.Resources;
using Conley.SocialPlatform.Bugers.Domain.Entities;

namespace Conley.SocialPlatform.Bugers.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RestaurantEntity, RestaurantResource>()
                .ForMember(dest=>dest.OpenTime,opt=>opt.MapFrom(src=>((DateTime)src.OpenTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => ((DateTime)src.EndTime)));
            CreateMap<RatingEntity, RatingResource>().ReverseMap();
            CreateMap<ImageEntity, ImageResource>().ReverseMap();
            CreateMap<RatingDto, RatingEntity>().ReverseMap();
        }
    }
}
