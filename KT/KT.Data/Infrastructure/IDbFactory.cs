using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KTDbContext Init();
    }
}
