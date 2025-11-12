using AutoMapper;
using Microsoft.EntityFrameworkCore;

using ConcertMap.Data;
using ConcertMap.Dtos;
using ConcertMap.Interfaces;

namespace ConcertMap.Services
{
    public class FestivalService : IFestivalService
    {
        private readonly ConcertMapContext _context;
        private readonly IMapper _mapper;

        public FestivalService(ConcertMapContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FestivalSummaryDto>> GetFestivalSummariesAsync()
        {
            try
            { 
                var festivals = await _context.Festivals
                    .Include(f => f.Venue)
                    .Include(f => f.FestivalBands)
                        .ThenInclude(b => b.Band)
                    .OrderBy(f => f.Date)
                    .Select(f => new FestivalSummaryDto
                    {
                        Date = f.Date.ToString("MM-dd-yyyy"),
                        VenueName = f.Venue.Name,
                        FestivalName = f.Name,
                        Bands = f.FestivalBands
                            .Select(fb => fb.Band.Name)
                            .OrderBy(name => name)
                            .ToList()
                    })
                    .AsNoTracking()
                    .ToListAsync();
                
                return festivals;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting festival summaries: " + e.Message);
            }
        }
    }
}