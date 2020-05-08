using SistemaCompraGado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Interfaces.Validar
{
    public interface ICompraGadoValidar
    {
        bool ValidarCompraGado(CompraGado Compra);
        bool ValidarAtualizarCompraGado(CompraGado Compra);
    }
}
