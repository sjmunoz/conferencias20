﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class Conference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string UserId { get; set; }
        public int EventCenterId { get; set; }

        public int Spots { get; set; }
        public virtual EventCenter EventCenter { get; set; }
        public virtual ICollection<Repetition> Repetitions { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Talk> Talks { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Dinner> Dinners { get; set; }
        public virtual ICollection<Sponsor> Sponsors { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ConferenceUser> Attendants { get; set; }
    }
}