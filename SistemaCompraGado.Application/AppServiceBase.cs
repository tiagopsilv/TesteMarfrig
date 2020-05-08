using SistemaCompraGado.Application.Interfaces;
using SistemaCompraGado.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity GetById(long id)
        {
            return _serviceBase.GetById(id);
        }

        List<TEntity> IAppServiceBase<TEntity>.GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

 
    }
}
