using SistemaCompraGado.Application.Entities;
using SistemaCompraGado.Application.Interfaces;
using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaCompraGado.Application
{
    public class CompraGadoAppService : AppServiceBase<CompraGado>, ICompraGadoAppService
    {
        private readonly ICompraGadoService _CompraGadoService;
        public CompraGadoAppService(ICompraGadoService CompraGadoService)
            : base(CompraGadoService)
        {
            _CompraGadoService = CompraGadoService;
        }
        public CompraGado AdicionarCompra(CompraGado Compra)
        {
            return _CompraGadoService.AdicionarCompra(Compra);
        }

        public CompraGado AtualizarCompra(CompraGado Compra)
        {
            return _CompraGadoService.AtualizarCompra(Compra);
        }

        public List<PesquisarCompraGado> ConsultarLayoutPesquisar()
        {
            List<PesquisarCompraGado> Retorno = new List<PesquisarCompraGado>();

            foreach (CompraGado _CompraGado in _CompraGadoService.Consultar())
            {
               Retorno.Add(new PesquisarCompraGado
                {
                    ID = _CompraGado.ID,
                    DataEntrega = _CompraGado.DataEntrega,
                    NomePecuarista = _CompraGado.Pecuarisa.Nome,
                    PecuaristaID = _CompraGado.PecuaristaID,
                    ValorTotal = (_CompraGado.CompraDadoItem.Sum(x => (decimal.Parse(x.Animal.Preco) * int.Parse(x.Quantidade.Replace(".", "")))))
                });
            }

            return Retorno;
        }

        public List<CompraGado> Consultar()
        {
            return _CompraGadoService.Consultar();
        }

        public CompraGado ConsultarById(long IDCompraGado)
        {
            return _CompraGadoService.ConsultarById(IDCompraGado);
        }

        public CompraGado Excluir(long IDCompraGado)
        {
            return _CompraGadoService.ExcluirCompra(IDCompraGado);
        }
    }
}
