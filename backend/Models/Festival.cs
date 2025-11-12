using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertMap.Models
{
    public class Festival 
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int VenueId { get; set; }

        public Venue Venue { get; set; } = null!;
        public ICollection<FestivalBand> FestivalBands { get; set; } = new List<FestivalBand>();

    }
}