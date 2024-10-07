using System.ComponentModel.DataAnnotations;

namespace Application.Models.Response
{
    public class CreatePlayerResponse
    {
        [Required]
        public required Guid Id { get; set; }
    }
}
