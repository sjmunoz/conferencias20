using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Party : Event
    {
        public virtual Room Room { get; set; }
        public virtual Conference Conference { get; set; }
    }
}
