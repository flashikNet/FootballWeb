using System.ComponentModel.DataAnnotations;

namespace Dal.Player.Models
{
    public class TeamDal
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
