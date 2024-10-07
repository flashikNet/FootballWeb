using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class CreatePlayerRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Surname { get; set; }
        [Required]
        public required string Sex { get; set; }
        [Required]
        public required string BirthDate { get; set; }
        [Required]
        public required string TeamName { get; set; }
        [Required]
        public required string Country { get; set; }
    }
}
