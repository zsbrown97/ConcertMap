using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertMap.Models
{
    public class Concert 
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int VenueId { get; set; }

        public Venue Venue { get; set; } = null!;
        public ICollection<Headliner> Headliners { get; set; } = new List<Headliner>();
    }
}