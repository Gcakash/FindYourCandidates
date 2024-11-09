using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CandidateFinder.Models;
using CandidateFinder.Data.EntityMap;

namespace CandidateFinder.Data.CandidateFinderDbContext
{
    public class AppllicationDbContext : DbContext
    {
        public AppllicationDbContext(DbContextOptions<AppllicationDbContext> options)
                    : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configuration
            modelBuilder.ApplyConfiguration(new CandidateMap());
        }
    }
}
