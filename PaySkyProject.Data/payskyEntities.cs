using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using paysky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paysky.Data
{
    public class PayskyEntities : IdentityDbContext<ApplicationUser>
    {
        public PayskyEntities(DbContextOptions<PayskyEntities> option) : base(option) { }

        public DbSet<Transaction> Transactions { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TransactionConfigurations());

            //seed data 
            payskySeedData.Seed(modelBuilder);
        }
    }
}
