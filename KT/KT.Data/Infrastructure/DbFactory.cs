using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        KTDbContext dbContext;

        public KTDbContext Init()
        {
            return dbContext ?? (dbContext = new KTDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
