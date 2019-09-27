using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class EventCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public string ContactInfo { get; set; }
        public string Address { get; set; }
    }
}