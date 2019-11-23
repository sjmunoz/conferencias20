using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class ConferenceUser
    {
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
