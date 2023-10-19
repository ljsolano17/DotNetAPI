using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;

namespace Solution.DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options): base(options)
        {
        }

        public virtual DbSet<GroupComment> GroupComments { get; set; }
        public virtual DbSet<GroupUpdateSupport> GroupUpdateSupports { get; set; }
        public virtual DbSet<GroupUpdate> GroupUpdates { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GroupComment>(entity =>
            {
                entity.HasKey(e => e.GroupCommentId).HasName("PK_dbo.GroupComments");

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.HasOne(d => d.GroupUpdate).WithMany(p => p.GroupComments)
                    .HasForeignKey(d => d.GroupUpdateId)
                    .HasConstraintName("FK_dbo.GroupComments_dbo.GroupUpdates_GroupUpdateId");
            });

            modelBuilder.Entity<GroupUpdate>(entity =>
            {
                entity.HasKey(e => e.GroupUpdateId).HasName("PK_dbo.GroupUpdates");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GroupUpdateSupport>(entity =>
            {
                entity.HasKey(e => e.GroupUpdateSupportId)
                .HasName("PK_dbo.GroupUpdateSupports");

                entity.Property(e => e.UpdateSupportedDate).HasColumnType("datetime");

                entity.HasOne(d => d.GroupUpdate)
                    .WithMany(p => p.GroupUpdateSupports).HasForeignKey(d => d.GroupUpdateId)
                    .HasConstraintName("FK_dbo.GroupUpdateSupports_dbo.GroupUpdates_GroupUpdateId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
