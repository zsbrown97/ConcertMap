using System.ComponentModel.DataAnnotations;

namespace ConcertMap.Dtos
{
    public class FestivalSummaryDto
    {
        public string Date { get; set; }
        public string VenueName { get; set; }
        public string FestivalName { get; set; }
        public List<string> Bands { get; set; }
    }
}