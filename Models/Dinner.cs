using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Dinner : Event
    {
        public string Location { get; set; }
        public string Menu { get; set; }
        public virtual Room Room { get; set; }
    }
}
