using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Football.Models
{
    public class PlayerViewDal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
    }
}
