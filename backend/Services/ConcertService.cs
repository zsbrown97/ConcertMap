using Microsoft.EntityFrameworkCore;

using ConcertMap.Data;
using ConcertMap.Dtos;
using ConcertMap.Interfaces;

namespace ConcertMap.Services
{
    public class ConcertService : IConcertService
    {
        private readonly ConcertMapContext _context;

        public ConcertService(ConcertMapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConcertSummaryDto>> GetConcertSummariesAsync()
        {
            try
            { 
                return await _context.Concerts
                    .Include(c => c.Venue)
                    .Include(c => c.Headliners)
                        .ThenInclude(h => h.Band)
                    .Include(c => c.Openers)
                        .ThenInclude(o => o.Band)
                    .OrderBy(c => c.Date)
                    .Select(c => new ConcertSummaryDto
                    {
                        Date = c.Date.ToString("MM-dd-yyyy"),
                        VenueName = c.Venue.Name,
                        Headliners = c.Headliners.Select(h => h.Band.Name).ToList(),
                        Openers =  c.Openers.Select(o => o.Band.Name).ToList(),
                    })
                    .AsNoTracking()
                    .ToListAsync();
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
                return await _context.Concerts
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
                    .Select(c => new ConcertSummaryDto
                    {
                        Date = c.Date.ToString("MM-dd-yyyy"),
                        VenueName = c.Venue.Name,
                        Headliners = c.Headliners.Select(h => h.Band.Name).ToList(),
                        Openers = c.Openers.Select(o => o.Band.Name).ToList(),
                    })
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting concert summaries: " + e.Message);
            }
        }
    }
}