using Domain.Enums;

namespace Domain.Entities
{
    public class Player : EntityBase
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required Sex Sex { get; set; }
        /// <summary>
        /// Формат yyyy-MM-dd
        /// </summary>
        public required string BirthDate { get; set; }
        public required Team Team { get; set; }
        public required Country Country { get; set; }
    }
}
