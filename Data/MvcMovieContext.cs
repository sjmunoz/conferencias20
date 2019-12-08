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

            modelBuilder.Entity<PartyUser>()
                .HasKey(bc => new { bc.UserId, bc.PartyId });
            modelBuilder.Entity<PartyUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.AttendParties)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<PartyUser>()
                .HasOne(bc => bc.Party)
                .WithMany(c => c.Attendants)
                .HasForeignKey(bc => bc.PartyId);

            modelBuilder.Entity<TalkUser>()
                .HasKey(bc => new { bc.UserId, bc.TalkId });
            modelBuilder.Entity<TalkUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.AttendTalks)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<TalkUser>()
                .HasOne(bc => bc.Talk)
                .WithMany(c => c.Attendants)
                .HasForeignKey(bc => bc.TalkId);

            modelBuilder.Entity<ChatUser>()
                .HasKey(bc => new { bc.UserId, bc.ChatId });
            modelBuilder.Entity<ChatUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.AttendChats)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<ChatUser>()
                .HasOne(bc => bc.Chat)
                .WithMany(c => c.Attendants)
                .HasForeignKey(bc => bc.ChatId);
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

        public DbSet<MvcMovie.Models.PartyUser> PartyUser { get; set; }
        public DbSet<MvcMovie.Models.TalkUser> TalkUser { get; set; }
        public DbSet<MvcMovie.Models.ChatUser> ChatUser { get; set; }
    }
}
