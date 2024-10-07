using System.ComponentModel.DataAnnotations;

namespace Application.Models.Response
{
    public class EditPlayerResponse
    {
        [Required]
        public Guid Id { get; set; }
    }
}
