using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkAPI.Model.Context
{
    public class FrameworkAPIDbContext : DbContext
    {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public FrameworkAPIDbContext()
        {
        }

        public FrameworkAPIDbContext(DbContextOptions<FrameworkAPIDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasOne(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.IdAddress)
                .HasConstraintName("UserAddressFKConstraint");

                u.HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.IdCompany)
                .HasConstraintName("UserCompanyFKConstraint");

                u.HasIndex(u => u.Username)
                .IsUnique();

                u.HasIndex(u => u.Guid)
                .IsUnique();
            });

            modelBuilder.Entity<Address>(a =>
            {
                a.HasOne(a => a.Geo)
                .WithMany(g => g.Addresses)
                .HasForeignKey(a => a.IdGeo)
                .HasConstraintName("AddressGeoFKConstraint");
            });

            modelBuilder.Entity<Post>(p =>
            {
                p.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.IdUser)
                .HasConstraintName("PostUserFKConstraint");
            });

            modelBuilder.Entity<Comment>(c =>
            {
                c.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.IdPost)
                .HasConstraintName("CommentPostFKConstraint");
            });

            modelBuilder.Entity<Album>(a =>
            {
                a.HasOne(a => a.User)
                .WithMany(u => u.Albums)
                .HasForeignKey(a => a.IdUser)
                .HasConstraintName("AlbumUserFKConstraint");
            });

            modelBuilder.Entity<Photo>(p =>
            {
                p.HasOne(p => p.Album)
                .WithMany(a => a.Photos)
                .HasForeignKey(p => p.IdAlbum)
                .HasConstraintName("PhotoAlbumFKConstraint");
            });
        }
    }
}
