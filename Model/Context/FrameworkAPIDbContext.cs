using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model.Context
{
    public class FrameworkAPIDbContext : DbContext
    {

        public DbSet<address> Addresses { get; set; }
        public DbSet<album> Albums { get; set; }
        public DbSet<company> Companies { get; set; }
        public DbSet<comment> Comments { get; set; }
        public DbSet<geo> Geos { get; set; }
        public DbSet<photo> Photos { get; set; }
        public DbSet<post> Posts { get; set; }
        public DbSet<user> Users { get; set; }

        public FrameworkAPIDbContext()
        {
        }

        public FrameworkAPIDbContext(DbContextOptions<FrameworkAPIDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>(u =>
            {
                u.HasOne(u => u.address)
                .WithOne(a => a.user)
                .HasForeignKey<address>(a => a.idUser)
                .HasConstraintName("UserAddressFKConstraint");

                u.HasOne(u => u.company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.idCompany)
                .HasConstraintName("UserCompanyFKConstraint");
            });

            modelBuilder.Entity<address>(a =>
            {
                a.HasOne(a => a.geo)
                .WithOne(a => a.address)
                .HasForeignKey<geo>(g => g.idAddress)
                .HasConstraintName("AddressGeoFKConstraint");
            });

            modelBuilder.Entity<post>(p =>
            {
                p.HasOne(p => p.user)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.userId)
                .HasConstraintName("PostUserFKConstraint");
            });

            modelBuilder.Entity<comment>(c =>
            {
                c.HasOne(c => c.post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.postId)
                .HasConstraintName("CommentPostFKConstraint");
            });

            modelBuilder.Entity<album>(a =>
            {
                a.HasOne(a => a.user)
                .WithMany(u => u.Albums)
                .HasForeignKey(a => a.userId)
                .HasConstraintName("AlbumUserFKConstraint");
            });

            modelBuilder.Entity<photo>(p =>
            {
                p.HasOne(p => p.album)
                .WithMany(a => a.Photos)
                .HasForeignKey(p => p.albumId)
                .HasConstraintName("PhotoAlbumFKConstraint");
            });
        }
    }
}
