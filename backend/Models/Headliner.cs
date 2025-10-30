using System.ComponentModel.DataAnnotations;

namespace ConcertMap.Models
{
    public class Headliner
    {
        public int ConcertId { get; set; }
        public int BandId { get; set; }

        public Concert Concert { get; set; } = null!;
        public Band Band { get; set; } = null!;
    }
}