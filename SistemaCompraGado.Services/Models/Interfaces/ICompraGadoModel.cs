using SistemaCompraGado.Application.Entities;
using SistemaCompraGado.Services.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCompraGado.Services.Models.Interfaces
{
    public interface ICompraGadoModel
    {
        Retorno InserirCompraGado(CompraGadoWebAPI value);
        Retorno AlterarCompraGado(CompraGadoWebAPI value);
        Retorno ExcluirCompraGado(CompraGadoWebAPI IDCompraGado);
        List<PesquisarCompraGado> ConsultarCompraGado();
        CompraGadoWebAPI ConsultarById(string IDCompraGado);
    }
}
