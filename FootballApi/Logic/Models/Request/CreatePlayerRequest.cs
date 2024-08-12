using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CreatePlayerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public uint TeamId { get; set; }
        public string TeamName { get; set; }
        public int Country { get; set; }
    }
}
