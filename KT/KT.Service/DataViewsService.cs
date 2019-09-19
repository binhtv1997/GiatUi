using KT.Data.Infrastructure;
using KT.Data.Repositories;
using KT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Service
{
    public interface IDataViewsService
    {
        IQueryable<DataViews> GetDataViews();
        void UpdateBlock(DataViews Block);
        void DeleteBlock(DataViews Block);
        void CreateData(DataViews data);
        void Save();
    }
    public class DataViewsService : IDataViewsService
    {
        private readonly IDataViewsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DataViewsService(IDataViewsRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void CreateData(DataViews data)
        {
            data.DateCreate = DateTime.Now;
            _repository.Add(data);
        }

        public void DeleteBlock(DataViews Block)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DataViews> GetDataViews()
        {
            return _repository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateBlock(DataViews Block)
        {
            throw new NotImplementedException();
        }
    }
}
