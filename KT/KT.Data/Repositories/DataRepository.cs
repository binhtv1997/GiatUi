using KT.Data.Infrastructure;
using KT.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Data.Repositories
{
    public interface IDataViewsRepository : IRepository<DataViews>
    {

    }
    public class DataViewsRepository : RepositoryBase<DataViews>, IDataViewsRepository
    {
        public DataViewsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
