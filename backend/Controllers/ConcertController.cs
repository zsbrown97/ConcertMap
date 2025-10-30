using Microsoft.AspNetCore.Mvc;

using ConcertMap.Dtos;
using ConcertMap.Interfaces;

namespace ConcertMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcertController : ControllerBase
    {
        IConcertService _concertService;

        public ConcertController(IConcertService concertService)
        {
            _concertService = concertService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConcertSummaryDto>>> GetConcertSummaries()
        {
            var result = await _concertService.GetConcertSummariesAsync();
            return Ok(result);
        }
    }
}