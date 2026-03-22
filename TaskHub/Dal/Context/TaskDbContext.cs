using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context;

public sealed class TaskDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("tasks");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();

            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}