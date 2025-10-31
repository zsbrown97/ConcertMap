using ConcertMap.Dtos;

namespace ConcertMap.Interfaces
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueDto>> GetAllVenuesAsync();
        Task<IEnumerable<VenueDto>> GetVenuesByBandIdAsync(int bandId);
    }
}