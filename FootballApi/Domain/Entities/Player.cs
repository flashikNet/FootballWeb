using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player : EntityBase
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Sex { get; set; }
        public required string BirthDate { get; set; }
        public required Team Team { get; set; }
        public required Country Country { get; set; }
    }
}
