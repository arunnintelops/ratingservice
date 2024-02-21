using AutoMapper;

using Application.Commands.RatingService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Rating, RatingResponse>().ReverseMap();
            CreateMap<Rating, CreateRatingCommand>().ReverseMap();
            CreateMap<Rating, UpdateRatingCommand>().ReverseMap();
          
        }
    }
}
