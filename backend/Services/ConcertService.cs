using AutoMapper;
using Microsoft.EntityFrameworkCore;

using ConcertMap.Data;
using ConcertMap.Dtos;
using ConcertMap.Interfaces;

namespace ConcertMap.Services
{
    public class ConcertService : IConcertService
    {
        private readonly ConcertMapContext _context;
        private readonly IMapper _mapper;

        public ConcertService(ConcertMapContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConcertSummaryDto>> GetConcertSummariesAsync()
        {
            try
            { 
                var concerts = await _context.Concerts
                    .Include(c => c.Venue)
                    .Include(c => c.Headliners)
                        .ThenInclude(h => h.Band)
                    .Include(c => c.Openers)
                        .ThenInclude(o => o.Band)
                    .Select(c => new ConcertSummaryDto
                    {
                        Date = c.Date.ToString("MM-dd-yyyy"),
                        VenueName = c.Venue.Name,
                        Headliners = c.Headliners.Select(h => h.Band.Name).ToList(),
                        Openers =  c.Openers.Select(o => o.Band.Name).ToList(),
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return concerts;

            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting concert summaries: " + e.Message);
            }
        }
    }
}