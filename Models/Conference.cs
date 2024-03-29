﻿using System;
using System.ComponentModel.DataAnnotations;

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
    }
}