﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcMovie.Models;

namespace MvcMovie.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    [Migration("20191208195202_TalkAttendants")]
    partial class TalkAttendants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MvcMovie.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Career");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Lastname");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("University");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MvcMovie.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConferenceId");

                    b.Property<DateTime>("EndEventDate");

                    b.Property<DateTime>("EventDate");

                    b.Property<int>("ModeratorId");

                    b.Property<int>("RoomID");

                    b.Property<string>("Track");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("RoomID");

                    b.HasIndex("UserId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("MvcMovie.Models.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("EventCenterId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<int>("Spots");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventCenterId");

                    b.HasIndex("UserId");

                    b.ToTable("Conference");
                });

            modelBuilder.Entity("MvcMovie.Models.ConferenceNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConferenceId");

                    b.Property<string>("Message");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("UserId");

                    b.ToTable("ConferenceNotification");
                });

            modelBuilder.Entity("MvcMovie.Models.ConferenceUser", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("ConferenceId");

                    b.HasKey("UserId", "ConferenceId");

                    b.HasIndex("ConferenceId");

                    b.ToTable("ConferenceUser");
                });

            modelBuilder.Entity("MvcMovie.Models.Dinner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConferenceId");

                    b.Property<DateTime>("EndEventDate");

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("Location");

                    b.Property<string>("Menu");

                    b.Property<int>("RoomID");

                    b.Property<string>("Track");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("RoomID");

                    b.HasIndex("UserId");

                    b.ToTable("Dinner");
                });

            modelBuilder.Entity("MvcMovie.Models.EventCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ContactInfo");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("EventCenter");
                });

            modelBuilder.Entity("MvcMovie.Models.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConferenceId");

                    b.Property<DateTime>("EndEventDate");

                    b.Property<DateTime>("EventDate");

                    b.Property<int>("RoomID");

                    b.Property<string>("Track");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("RoomID");

                    b.HasIndex("UserId");

                    b.ToTable("Party");
                });

            modelBuilder.Entity("MvcMovie.Models.PartyUser", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("PartyId");

                    b.HasKey("UserId", "PartyId");

                    b.HasIndex("PartyId");

                    b.ToTable("PartyUser");
                });

            modelBuilder.Entity("MvcMovie.Models.Repetition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConferenceId");

                    b.Property<int>("Day");

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Repetition");
                });

            modelBuilder.Entity("MvcMovie.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<int>("EventCenterId");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.HasIndex("EventCenterId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("MvcMovie.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConferenceId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Sponsor");
                });

            modelBuilder.Entity("MvcMovie.Models.Talk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConferenceId");

                    b.Property<DateTime>("EndEventDate");

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("Resources");

                    b.Property<int>("RoomID");

                    b.Property<string>("Talker");

                    b.Property<string>("Track");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("RoomID");

                    b.HasIndex("UserId");

                    b.ToTable("Talk");
                });

            modelBuilder.Entity("MvcMovie.Models.TalkUser", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("TalkId");

                    b.HasKey("UserId", "TalkId");

                    b.HasIndex("TalkId");

                    b.ToTable("TalkUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MvcMovie.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MvcMovie.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MvcMovie.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MvcMovie.Models.Chat", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany("Chats")
                        .HasForeignKey("ConferenceId");

                    b.HasOne("MvcMovie.Models.Room", "Room")
                        .WithMany("Chats")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MvcMovie.Models.Conference", b =>
                {
                    b.HasOne("MvcMovie.Models.EventCenter", "EventCenter")
                        .WithMany()
                        .HasForeignKey("EventCenterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("Conferences")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MvcMovie.Models.ConferenceNotification", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("ConferenceNotifications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MvcMovie.Models.ConferenceUser", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany("Attendants")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("AttendConferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MvcMovie.Models.Dinner", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany("Dinners")
                        .HasForeignKey("ConferenceId");

                    b.HasOne("MvcMovie.Models.Room", "Room")
                        .WithMany("Dinners")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("Dinners")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MvcMovie.Models.Party", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany("Parties")
                        .HasForeignKey("ConferenceId");

                    b.HasOne("MvcMovie.Models.Room", "Room")
                        .WithMany("Parties")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("Parties")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MvcMovie.Models.PartyUser", b =>
                {
                    b.HasOne("MvcMovie.Models.Party", "Party")
                        .WithMany("Attendants")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("AttendParties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MvcMovie.Models.Repetition", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany("Repetitions")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MvcMovie.Models.Room", b =>
                {
                    b.HasOne("MvcMovie.Models.EventCenter", "EventCenter")
                        .WithMany("Rooms")
                        .HasForeignKey("EventCenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MvcMovie.Models.Sponsor", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany("Sponsors")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MvcMovie.Models.Talk", b =>
                {
                    b.HasOne("MvcMovie.Models.Conference", "Conference")
                        .WithMany("Talks")
                        .HasForeignKey("ConferenceId");

                    b.HasOne("MvcMovie.Models.Room", "Room")
                        .WithMany("Talks")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("Talks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MvcMovie.Models.TalkUser", b =>
                {
                    b.HasOne("MvcMovie.Models.Talk", "Talk")
                        .WithMany("Attendants")
                        .HasForeignKey("TalkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcMovie.Models.ApplicationUser", "User")
                        .WithMany("AttendTalks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
