using Employee.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);
                entity.Property(e => e.EmployeeName)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(e => e.EmployeeAddress)
                      .IsRequired()
                      .HasMaxLength(30);
            });

            // Configure other entities if necessary
        }
    }
}