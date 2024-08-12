using System.ComponentModel.DataAnnotations;

namespace Application.Models.Response
{
    public class GetPlayerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public string Country { get; set; }
    }
}
