using System.ComponentModel.DataAnnotations;

namespace ConcertMap.Models
{
    public class Band 
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}