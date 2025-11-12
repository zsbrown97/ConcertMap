using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using ConcertMap.Data;
using ConcertMap.Dtos;
using ConcertMap.Interfaces;

namespace ConcertMap.Services
{
    public class VenueService : IVenueService
    {
        private readonly ConcertMapContext _context;
        private readonly IMapper _mapper;

        public VenueService(ConcertMapContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VenueDto>> GetAllVenuesAsync()
        {
            try
            {
                return await _mapper.ProjectTo<VenueDto>(_context.Venues)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting all venues: " + e.Message);
            }
        }

        public async Task<IEnumerable<VenueDto>> GetVenuesByBandIdAsync(int bandId)
        {
            try
            {
                var concertVenuesQuery = _context.Concerts
                    .Where(c => c.Headliners.Any(h => h.BandId == bandId) ||
                                c.Openers.Any(o => o.BandId == bandId))
                    .Select(c => c.Venue);
                var festivalVenuesQuery = _context.Festivals
                    .Where(f => f.FestivalBands.Any(b => b.BandId == bandId))
                    .Select(f => f.Venue);
                
                var combinedVenueQuery = await concertVenuesQuery
                    .Union(festivalVenuesQuery)
                    .ProjectTo<VenueDto>(_mapper.ConfigurationProvider)
                    .Distinct()
                    .AsNoTracking()
                    .ToListAsync();
                
                return combinedVenueQuery;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting venues: " + e.Message);
            }
        }
    }
}