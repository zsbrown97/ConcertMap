using Microsoft.AspNetCore.Mvc;

using ConcertMap.Dtos;
using ConcertMap.Interfaces;

namespace ConcertMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivalController : ControllerBase
    {
        IFestivalService _festivalService;

        public FestivalController(IFestivalService festivalService)
        {
            _festivalService = festivalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FestivalSummaryDto>>> GetFestivalSummaries()
        {
            var result = await _festivalService.GetFestivalSummariesAsync();
            return Ok(result);
        }
    }
}