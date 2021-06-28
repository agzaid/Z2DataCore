using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Z2DataCore.Models
{
    public partial class Z2DataContext : DbContext
    {
        public Z2DataContext()
        {
        }

        public Z2DataContext(DbContextOptions<Z2DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<InventoryProcess> InventoryProcesses { get; set; }
        public virtual DbSet<Process> Processes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Z2Data;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("goods");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<InventoryProcess>(entity =>
            {
                entity.ToTable("Inventory_process");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GoodId).HasColumnName("GoodID");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.InventoryProcesses)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("FK_Inventory_process_goods");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.InventoryProcesses)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_Inventory_process_process");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("process");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerName).HasMaxLength(250);

                entity.Property(e => e.DateProcess).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
