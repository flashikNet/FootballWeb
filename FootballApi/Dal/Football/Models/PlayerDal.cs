using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Player.Models
{
    public class PlayerDal
    {
        [Key]
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Sex { get; set; }
        public required string BirthDate { get; set; }
        public Guid TeamId { get; set; }
        public Guid CountryId { get; set; }

    }
}
