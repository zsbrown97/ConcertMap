using ConcertMap.Dtos;

namespace ConcertMap.Interfaces
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueDto>> GetAllVenuesAsync();
    }
}