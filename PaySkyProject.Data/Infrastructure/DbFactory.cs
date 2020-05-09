using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paysky.Data
{
    public class DbFactory : Disposable, IDbFactory
    {
        PayskyEntities dbContext;
        public PayskyEntities Init()
        {
            var options = new DbContextOptions<PayskyEntities>();
            return dbContext ?? (dbContext = new PayskyEntities(options));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
