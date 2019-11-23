using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class ConferenceNotification
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public int ConferenceId { get; set; }
        public virtual Conference Conference { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
