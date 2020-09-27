using dev.budget.business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace dev.budget
{
    public class DevBudgetContext : DbContext
    {
        //public DevBudgetContext(DbContextOptions<DevBudgetContext> options) : base(options)
        //{
        //}

              
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("dev_budgets");
            //optionsBuilder.UseSqlite("devbudgets.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonAddress>()
                .HasKey(nameof(PersonAddress.AddressId), nameof(PersonAddress.PersonId));

            modelBuilder.Entity<PersonEnterprise>()
                .HasKey(nameof(PersonEnterprise.EnterpriseId), nameof(PersonEnterprise.PersonId));
            //base.OnModelCreating(modelBuilder);
        }
    }
}
