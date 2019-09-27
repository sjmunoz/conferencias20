using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Talk : Event
    {
        public string Resources { get; set; }
        public int TalkerId { get; set; }
    }
}
