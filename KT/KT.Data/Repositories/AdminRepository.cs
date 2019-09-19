using KT.Data.Infrastructure;
using KT.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Data.Repositories
{
    public interface IAdminRepository : IRepository<Admin>
    {

    }
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
