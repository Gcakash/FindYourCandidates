using CandidateFinder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateFinder.Data.EntityMap
{
    public class CandidateMap : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder) 
        {
            // Primary Key
            builder.HasKey(c => c.Id);

            // Define properties with constraints
            builder.Property(c => c.FirstName)
                .IsRequired() // Nullable: false
                .HasMaxLength(50); // Max length constraint

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(c => c.PreferredCallTime)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(c => c.LinkedInUrl)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(c => c.GitHubUrl)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(c => c.Comment)
                .HasMaxLength(500)
                .IsRequired();

            // Unique constraint on Email
            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
