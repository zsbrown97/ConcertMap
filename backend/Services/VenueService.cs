using AutoMapper;
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
    }
}