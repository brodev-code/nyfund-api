using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using NyFund.Data.Entity.Model;
using NyFund.Data.DataAccessLayer.Database;

namespace NyFund.Data.Entity.Database
{
    public class NyFundDbContext : DbContextBase
    {
        public NyFundDbContext([NotNull] DbContextOptions<NyFundDbContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected NyFundDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.OtpActiveDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.BanEndDate).HasColumnType("datetime");
            });
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
