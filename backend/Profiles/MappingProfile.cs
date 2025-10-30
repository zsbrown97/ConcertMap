using AutoMapper;

using ConcertMap.Dtos;
using ConcertMap.Models;

namespace ConcertMap.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Venue 
            CreateMap<Venue, VenueDto>().ReverseMap();

        }
    }
}