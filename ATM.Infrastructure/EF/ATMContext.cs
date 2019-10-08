using ATM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Infrastructure.EF
{
    public class ATMContext : DbContext
    {

        public ATMContext(DbContextOptions<ATMContext> options) : base(options)
        { }
         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BankAccount>().ToTable("BankAccount");
            builder.Entity<Customer>().ToTable("Customer");

            builder.Entity<Customer>()
                .HasMany<BankAccount>(x => x.BankAccounts)
                .WithOne(x => x.Customer);

            builder.Entity<BankAccount>()
                .HasMany<Transaction>(x => x.Transactions)
                .WithOne(x => x.BankAccount);

        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Customer>  Customers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }



    }
}
