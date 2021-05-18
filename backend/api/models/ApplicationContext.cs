using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.CascadeDeleteTiming = Microsoft.EntityFrameworkCore.ChangeTracking.CascadeTiming.Never;
        }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.HasMany(p => p.Permissions)
                 .WithOne(b => b.Type)
                 .HasForeignKey(c => c.PermissionType)
                 .OnDelete(DeleteBehavior.NoAction);

                entity.HasData(new List<PermissionType>{
                    new PermissionType {Id = 1,Description = "Enfermedad"},
                    new PermissionType {Id = 2,Description = "Diligencias"},
                    new PermissionType {Id = 3,Description = "Otros"},
                });
            });

            modelBuilder.Entity<Permission>(entity =>
           {
               entity.HasOne(p => p.Type)
                .WithMany(b => b.Permissions)
                .HasForeignKey(c => c.PermissionType);
           });
        }
    }
}