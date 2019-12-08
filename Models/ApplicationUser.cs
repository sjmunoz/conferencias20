using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string University { get; set; }
        public string Career { get; set; }

        public virtual ICollection<Conference> Conferences { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Dinner> Dinners { get; set; }
        public virtual ICollection<Talk> Talks { get; set; }

        public virtual ICollection<ConferenceUser> AttendConferences { get; set; }

        public virtual ICollection<ConferenceNotification> ConferenceNotifications { get; set; }

        public virtual ICollection<PartyUser> AttendParties { get; set; }
        public virtual ICollection<TalkUser> AttendTalks { get; set; }

        public virtual ICollection<ChatUser> AttendChats { get; set; }

    }
}
