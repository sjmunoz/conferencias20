using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public class MvcMovieContext : IdentityDbContext<ApplicationUser>
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConferenceUser>()
                .HasKey(bc => new { bc.UserId, bc.ConferenceId });
            modelBuilder.Entity<ConferenceUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.AttendConferences)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<ConferenceUser>()
                .HasOne(bc => bc.Conference)
                .WithMany(c => c.Attendants)
                .HasForeignKey(bc => bc.ConferenceId);
        }

        public DbSet<MvcMovie.Models.Conference> Conference { get; set; }


        public DbSet<MvcMovie.Models.EventCenter> EventCenter { get; set; }

        public DbSet<MvcMovie.Models.Party> Party { get; set; }

        public DbSet<MvcMovie.Models.Dinner> Dinner { get; set; }

        public DbSet<MvcMovie.Models.Chat> Chat { get; set; }

        public DbSet<MvcMovie.Models.Talk> Talk { get; set; }

        public DbSet<MvcMovie.Models.Sponsor> Sponsor { get; set; }

        public DbSet<MvcMovie.Models.Room> Room { get; set; }

        public DbSet<MvcMovie.Models.ApplicationUser> User { get; set; }
        public DbSet<MvcMovie.Models.Repetition> Repetition { get; set; }

        public DbSet<MvcMovie.Models.ConferenceUser> ConferenceUser { get; set; }

        public DbSet<MvcMovie.Models.ConferenceNotification> ConferenceNotification { get; set; }
    }
}
