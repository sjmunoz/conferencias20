using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class PartyUser
    {
        public int PartyId { get; set; }
        public Party Party { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
