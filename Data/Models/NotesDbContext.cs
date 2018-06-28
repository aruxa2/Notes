using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Notes.Data.Models;

namespace Notes.Data.Models
{
    public partial class NotesDbContext : DbContext
    {
        public NotesDbContext()
        {
        }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ListItemList> ListItemList { get; set; }
        public virtual DbSet<ListItems> ListItems { get; set; }
        public virtual DbSet<Lists> Lists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=NotesDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListItemList>(entity =>
            {
                entity.HasKey(e => new { e.ListId, e.ListItemId });

                entity.HasOne(d => d.List)
                    .WithMany(p => p.ListItemList)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ListItemList_Lists1");

                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.ListItemList)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ListItemList_ListItems1");
            });

            modelBuilder.Entity<ListItems>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
