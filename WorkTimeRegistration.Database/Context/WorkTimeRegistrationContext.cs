using Microsoft.EntityFrameworkCore;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Database.Context
{
    public class WorkTimeRegistrationContext : DbContext
    {
        public WorkTimeRegistrationContext()
        {

        }

        public WorkTimeRegistrationContext(DbContextOptions<WorkTimeRegistrationContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorkEvent> WorkEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WorkTimeRegistrationDb;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Address>(p => p.Address)
                .WithOne(pp => pp.Employee)
                .HasForeignKey<Address>(pp => pp.EmpoleyyId);
        }
    }
}