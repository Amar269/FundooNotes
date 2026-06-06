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

        public DbSet<Notes> Notes { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<NoteLabel> NoteLabels { get; set; }


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

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(n => n.NotesId);

                entity.Property(n => n.NotesId)
                .ValueGeneratedOnAdd();

                entity.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(300);

                entity.Property(n => n.Description)
                      .HasColumnType("nvarchar(max)");


                entity.Property(n => n.Colour)
                      .HasDefaultValue("#FFFFFF");


                entity.Property(n => n.IsArchive)
                .HasDefaultValue(false);

                entity.Property(n => n.IsPin)
                .HasDefaultValue(false);

                entity.Property(n => n.IsTrash)
                      .HasDefaultValue(false);

                entity.Property(n => n.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(n => n.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

                // user one to  many notes relationship
                entity.HasOne(n => n.User)
                      .WithMany(u => u.Notes)
                      .HasForeignKey(n => n.UserId);
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.HasKey(l => l.LabelId);
                entity.Property(l => l.LabelId)
                      .ValueGeneratedOnAdd();

                entity.Property(l => l.LabelName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(l => l.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(l => l.UpdatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(l => l.user)
                      .WithMany()
                      .HasForeignKey(l => l.UserId);

                


            });

            modelBuilder.Entity<NoteLabel>(entity =>
            {
                entity.HasKey(nl => nl.NoteLabelId);

                entity.Property(nl => nl.NoteLabelId)
                      .ValueGeneratedOnAdd();

                entity.HasOne(nl => nl.notes)
                      .WithMany()
                      .HasForeignKey(nl => nl.NoteId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(nl => nl.label)
                      .WithMany()
                      .HasForeignKey(nl => nl.LabelId)
                      .OnDelete(DeleteBehavior.NoAction);
            });









        }
}
}
