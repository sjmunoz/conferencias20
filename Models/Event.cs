using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public abstract class Event
    {
        public int Id { get; set; }
        public int RoomID { get; set; }

        public int ConferenceId { get; set; }

        public int PersonId { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime EndEventDate { get; set; }

        public string Track { get; set; }
    }
}
