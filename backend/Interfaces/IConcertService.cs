using ConcertMap.Dtos;

namespace ConcertMap.Interfaces
{
    public interface IConcertService
    {
        Task<IEnumerable<ConcertSummaryDto>> GetConcertSummariesAsync();
    }
}