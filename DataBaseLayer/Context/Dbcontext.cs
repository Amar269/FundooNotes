using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Entity;



namespace DataBaseLayer.Context
{
    public  class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                
                entity.HasKey(u => u.UserId);

               
                entity.Property(u => u.UserId)
                      .ValueGeneratedOnAdd();

                
                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                
                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                
                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasIndex(u => u.Email)
                      .IsUnique();

                
                entity.Property(u => u.Password)
                      .IsRequired();

                
                entity.Property(u => u.CreatedAt)
                      .IsRequired();

                
                entity.Property(u => u.ChangedAt);
            });
        }



    }
}
