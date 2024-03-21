using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using NyFund.Data.Entity.Model;

namespace NyFund.Data.Entity.Database
{
    public class NyFundDbContext : DbContextBase
    {
        public IzaCodeDbContext([NotNull] DbContextOptions<IzaCodeDbContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected IzaCodeDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");
            });
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
