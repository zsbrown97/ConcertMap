using System.ComponentModel.DataAnnotations;

namespace ConcertMap.Models
{
    public class FestivalBand 
    {
        public int FestivalId { get; set; }
        public int BandId { get; set; }

        public Festival Festival { get; set; } = null!;
        public Band Band { get; set; } = null!;
    }
}