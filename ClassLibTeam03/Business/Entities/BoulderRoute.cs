using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam03.Business.Entities
{
    public class BoulderRoute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FontScale { get; set; }
        public string Country { get; set; }
        public string ClimbingStyle { get; set; }
        public string Description { get; set; }
        public DateTime? DateFirstAscent { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ImageUrl { get; set; }
    }
}
