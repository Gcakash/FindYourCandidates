﻿// <auto-generated />
using CandidateFinder.Data.CandidateFinderDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CandidateFinder.Data.Migrations
{
    [DbContext(typeof(AppllicationDbContext))]
    partial class AppllicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("CandidateFinder.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("GitHubUrl")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkedInUrl")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("PreferredCallTime")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
