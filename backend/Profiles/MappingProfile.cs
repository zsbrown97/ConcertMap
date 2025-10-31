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
            
            // Concert Summary
            CreateMap<Concert, ConcertSummaryDto>()
                .ForMember
                (
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date.ToString("MM-dd-yyyy"))
                )
                .ForMember
                (
                    dest => dest.VenueName,
                    opt => opt.MapFrom(src => src.Venue.Name)
                )
                .ForMember
                (
                    dest => dest.Headliners,
                    opt => opt.MapFrom(src => src.Headliners.Select(h => h.Band.Name).ToList())
                )
                .ForMember
                (
                    dest => dest.Openers,
                    opt => opt.MapFrom(src => src.Openers.Select(o => o.Band.Name).ToList())
                );


        }
    }
}