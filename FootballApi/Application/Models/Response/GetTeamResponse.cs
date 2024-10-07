using System.ComponentModel.DataAnnotations;

namespace Application.Models.Response
{
    public class GetTeamResponse
    {
        [Required]
        public required Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
