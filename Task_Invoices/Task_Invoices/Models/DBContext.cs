using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Task_Invoices.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<TUser> TUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .Property(e => e.Product)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Quantity)
                .IsUnicode(false);

            modelBuilder.Entity<TUser>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<TUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<TUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<TUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TUser>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.TUser)
                .HasForeignKey(e => e.Id_User);
        }
    }
}
