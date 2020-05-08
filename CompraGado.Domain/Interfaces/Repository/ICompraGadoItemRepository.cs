using SistemaCompraGado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Interfaces.Repository
{
    public interface ICompraGadoItemRepository : IRepositoryBase<CompraGadoItem>
    {
        List<CompraGadoItem> GetByCompraGadoId(long ID);
        void RemoveCompraGadoId(long ID);
    }
}
