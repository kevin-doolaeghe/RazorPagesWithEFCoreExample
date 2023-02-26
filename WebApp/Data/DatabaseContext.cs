using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Services
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Account> Accounts { get; set; } = default!;

        public DbSet<Record> Records { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Record>().ToTable("Records");
        }
    }
}
