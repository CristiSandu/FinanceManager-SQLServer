using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinanceManagerAPI.Database
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountInfoExt> AccountInfoExts { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Merchant> Merchants { get; set; } = null!;
        public virtual DbSet<Stat> Stats { get; set; } = null!;
        public virtual DbSet<TransactionAcc> TransactionAccs { get; set; } = null!;
        public virtual DbSet<TransactionInfoExt> TransactionInfoExts { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:finance-manager-db.database.windows.net,1433;Initial Catalog=FinanceManagerDb;Persist Security Info=False;User ID=azureuser;Password=parolaAiaPuternic4!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("bank_id_fk");

                entity.HasOne(d => d.Types)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.TypesId)
                    .HasConstraintName("types_id_fk");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Merchants)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("category_id_fk");
            });

            modelBuilder.Entity<Stat>(entity =>
            {
                entity.HasKey(e => e.StatsId)
                    .HasName("stats_id_pk");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Stats)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("account_id_fk");

                entity.HasOne(d => d.Types)
                    .WithMany(p => p.Stats)
                    .HasForeignKey(d => d.TypesId)
                    .HasConstraintName("types_id_stat_fk");
            });

            modelBuilder.Entity<TransactionAcc>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("transaction_id_pk");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TransactionAccs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("account_id_trans_fk");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TransactionAccs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("category_id_trans_fk");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.TransactionAccs)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("merchant_id_fk");

                entity.HasOne(d => d.Types)
                    .WithMany(p => p.TransactionAccs)
                    .HasForeignKey(d => d.TypesId)
                    .HasConstraintName("types_id_trans_fk");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.TypesId)
                    .HasName("types_id_pk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
