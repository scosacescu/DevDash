using Microsoft.EntityFrameworkCore;

namespace DevDash.Models
{
    public partial class DevDashDBContext : DbContext
    {
        public virtual DbSet<Dashboard> Dashboard { get; set; }
        public virtual DbSet<GitHub> GitHub { get; set; }
        public virtual DbSet<Trello> Trello { get; set; }

        public DevDashDBContext(DbContextOptions<DevDashDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dashboard>(entity =>
            {
                entity.Property(e => e.DashboardId)
                    .HasColumnName("dashboardID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoardId)
                    .IsRequired()
                    .HasColumnName("boardID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DashboardName)
                    .IsRequired()
                    .HasColumnName("dashboardName")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RepoId)
                    .IsRequired()
                    .HasColumnName("repoID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dashboard)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dashboard_ToUser");

                entity.HasOne(d => d.Trello)
                    .WithMany(p => p.Dashboard)
                    .HasForeignKey(d => new { d.UserId, d.BoardId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dashboard_ToTrello");

                entity.HasOne(d => d.GitHub)
                    .WithMany(p => p.Dashboard)
                    .HasForeignKey(d => new { d.UserId, d.RepoId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dashboard_ToGithub");
            });

            modelBuilder.Entity<GitHub>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RepoId });

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.RepoId)
                    .HasColumnName("repoID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RepoName)
                    .IsRequired()
                    .HasColumnName("repoName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GitHub)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GitHub_ToUser");
            });

            modelBuilder.Entity<Trello>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BoardId });

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.BoardId)
                    .HasColumnName("boardID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BoardName)
                    .IsRequired()
                    .HasColumnName("boardName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trello)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trello_ToUser");
            });
        }
    }
}
