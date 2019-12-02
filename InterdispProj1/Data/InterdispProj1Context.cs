using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InterdispProj1.Models
{
    public class InterdispProj1Context : DbContext
    {
        public InterdispProj1Context (DbContextOptions<InterdispProj1Context> options)
            : base(options)
        {
        }

        public DbSet<DataEntry> DataEntries { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Requirement> Requirements { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
