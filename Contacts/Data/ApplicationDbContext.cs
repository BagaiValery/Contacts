using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasMany(o => o.Contacts).WithOne(x => x.Job).HasForeignKey(x => x.JobId);
            modelBuilder.Entity<Contact>().HasOne(c => c.Job).WithMany(x => x.Contacts).HasForeignKey(x => x.JobId).IsRequired(false);
        }
    }
}
