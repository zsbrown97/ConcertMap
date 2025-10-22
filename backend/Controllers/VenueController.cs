using Microsoft.AspNetCore.Mvc;

using ConcertMap.Dtos;
using ConcertMap.Interfaces;

namespace ConcertMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VenueController : ControllerBase
    {
        IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueDto>>> GetAllVenues()
        {
            var result = await _venueService.GetAllVenuesAsync();
            return Ok(result);
        }
    }
}