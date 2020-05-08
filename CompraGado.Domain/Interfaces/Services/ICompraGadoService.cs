using SistemaCompraGado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Interfaces.Services
{
    public interface ICompraGadoService : IServiceBase<CompraGado>
    {
        CompraGado AdicionarCompra(CompraGado Compra);
        CompraGado AtualizarCompra(CompraGado Compra);
        List<CompraGado> Consultar();
        CompraGado ConsultarById(long IDCompraGado);
        CompraGado ExcluirCompra(long IDCompraGado);
    }
}
