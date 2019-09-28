using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public class MvcMovieContext : IdentityDbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Conference> Conference { get; set; }

        public DbSet<MvcMovie.Models.EventCenter> EventCenter { get; set; }

        public DbSet<MvcMovie.Models.User> User { get; set; }

        public DbSet<MvcMovie.Models.Speaker> Speaker { get; set; }

        public DbSet<MvcMovie.Models.Party> Party { get; set; }

        public DbSet<MvcMovie.Models.Dinner> Dinner { get; set; }

        public DbSet<MvcMovie.Models.Chat> Chat { get; set; }

        public DbSet<MvcMovie.Models.Talk> Talk { get; set; }
    }
}
