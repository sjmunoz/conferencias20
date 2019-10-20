using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Chat : Event
    {
        public string Topic { get; set; }
        public int ModeratorId { get; set; }
        public virtual Room Room { get; set; }
    }
}
