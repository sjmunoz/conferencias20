using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class TalkUser
    {
        public int TalkId { get; set; }
        public Talk Talk { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int? Rating { get; set; }
    }
}
