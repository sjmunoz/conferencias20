using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Talk
    {
        public int Id { get; set; }
        public int RoomID { get; set; }

        public int? ConferenceId { get; set; }

        public string UserId { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime EndEventDate { get; set; }

        public string Track { get; set; }
        public string Resources { get; set; }
        public string Talker { get; set; }
        public virtual Room Room { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Conference Conference { get; set; }
    }
}
