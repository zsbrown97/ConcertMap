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
                    .OrderBy(c => c.Date)
                    .AsNoTracking()
                    .ToListAsync();
                
                return _mapper.Map<IEnumerable<ConcertSummaryDto>>(concerts);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting concert summaries: " + e.Message);
            }
        }

        public async Task<IEnumerable<ConcertSummaryDto>> GetConcertSummariesByBandAsync(int bandId)
        {
            try
            {
                var concerts = await _context.Concerts
                    .Include(c => c.Venue)
                    .Include(c => c.Headliners)
                        .ThenInclude(h => h.Band)
                    .Include(c => c.Openers)
                        .ThenInclude(o => o.Band)
                    .Where(c => 
                        c.Headliners.Any(h => h.BandId == bandId) || 
                        c.Openers.Any(o => o.BandId == bandId)
                    )
                    .OrderBy(c => c.Date)
                    .AsNoTracking()
                    .ToListAsync();
                
                return _mapper.Map<IEnumerable<ConcertSummaryDto>>(concerts);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting concert summaries: " + e.Message);
            }
        }
    }
}