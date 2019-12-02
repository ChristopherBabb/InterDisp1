using InterdispProj1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InterdispProj1.Data
{
    public class DataEntryDbContext : DbContext
    {
        public DataEntryDbContext(DbContextOptions<DataEntryDbContext> options): base(options)
        {

        }

        public DbSet<DataEntry> DataEntries { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Requirement> Requirements { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}