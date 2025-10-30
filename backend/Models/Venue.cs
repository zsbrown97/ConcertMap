using System.ComponentModel.DataAnnotations;

namespace ConcertMap.Models
{
    public class Venue
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? PreviousNames { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}