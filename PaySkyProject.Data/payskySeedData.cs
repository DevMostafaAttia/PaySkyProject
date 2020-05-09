using Microsoft.EntityFrameworkCore;
using paysky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paysky.Data
{
    class payskySeedData //: DropCreateDatabaseIfModelChanges<PayskyEntities>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { }
                );
        }

    }
}
