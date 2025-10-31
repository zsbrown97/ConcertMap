using ConcertMap.Dtos;

namespace ConcertMap.Interfaces
{
    public interface IConcertService
    {
        Task<IEnumerable<ConcertSummaryDto>> GetConcertSummariesAsync();
        Task<IEnumerable<ConcertSummaryDto>> GetConcertSummariesByBandAsync(int bandId);
    }
}