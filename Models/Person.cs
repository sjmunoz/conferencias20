using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public abstract class Person
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }

        public string Genre { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
