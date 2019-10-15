using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
    }
}
