using SistemaCompraGado.Application.Entities;
using SistemaCompraGado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Application.Interfaces
{
    public interface ICompraGadoAppService : IAppServiceBase<CompraGado>
    {
        CompraGado AdicionarCompra(CompraGado Compra);
        CompraGado AtualizarCompra(CompraGado Compra);
        List<PesquisarCompraGado> ConsultarLayoutPesquisar();
        List<CompraGado> Consultar();
        CompraGado ConsultarById(long IDCompraGado);
        CompraGado Excluir(long IDCompraGado);
    }
}
