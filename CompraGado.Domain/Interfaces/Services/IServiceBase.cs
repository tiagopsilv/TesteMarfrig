using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(long ID);
        List<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
