using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevDash.Models;

namespace DevDash.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Dashboard>(entity =>
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

            builder.Entity<GitHub>(entity =>
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

            builder.Entity<Trello>(entity =>
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

        public DbSet<DevDash.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<DevDash.Models.Dashboard> Dashboard { get; set; }
    }
}
