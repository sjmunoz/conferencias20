using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class DinnerUser
    {
        public int DinnerId { get; set; }
        public Dinner Dinner { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
