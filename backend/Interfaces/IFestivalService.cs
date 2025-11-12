using ConcertMap.Dtos;

namespace ConcertMap.Interfaces
{
    public interface IFestivalService
    {
        Task<IEnumerable<FestivalSummaryDto>> GetFestivalSummariesAsync();
    }
}