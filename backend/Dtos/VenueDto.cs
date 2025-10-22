using System.ComponentModel.DataAnnotations;

namespace ConcertMap.Dtos
{
    public class VenueDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string? previous_names { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public double latitude { get; set; }
        [Required]
        public double longitude { get; set; }
    }
}