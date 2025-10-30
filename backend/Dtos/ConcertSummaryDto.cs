using System.ComponentModel.DataAnnotations;

namespace ConcertMap.Dtos
{
    public class ConcertSummaryDto
    {
        public DateTime Date { get; set; }
        public string VenueName { get; set; }
        public List<string> Headliners { get; set; }
    }
}