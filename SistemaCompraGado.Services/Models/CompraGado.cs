using SistemaCompraGado.Application.Entities;
using SistemaCompraGado.Application.Interfaces;
using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Services.Models;
using SistemaCompraGado.Services.Models.Entities;
using SistemaCompraGado.Services.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCompraGado.Services.Models
{
    public class CompraGadoModel : ICompraGadoModel
    {
        private readonly ICompraGadoAppService _CompraGadoAppService;

        public CompraGadoModel(ICompraGadoAppService CompraGadoAppService)
        {
            _CompraGadoAppService = CompraGadoAppService;
        }

        public Retorno InserirCompraGado(CompraGadoWebAPI value)
        {
            try
            {
                List<CompraGadoItem> _LstCompraGadoItem = new List<CompraGadoItem>();

                foreach (CompraGadoItemWebAPI _CompraGadoItemWebAPI in value.CompraDadoItem)
                    _LstCompraGadoItem.Add(new CompraGadoItem { CompraGadoID = _CompraGadoItemWebAPI.CompraGadoID, AnimalID = _CompraGadoItemWebAPI.AnimalID, Quantidade = _CompraGadoItemWebAPI.Quantidade });

                _CompraGadoAppService.AdicionarCompra(new CompraGado { ID = value.ID, DataEntrega = value.DataEntrega, PecuaristaID = value.PecuaristaID, CompraDadoItem = _LstCompraGadoItem });

                return new Retorno { Sucesso = true };

            }
            catch (Exception ex)
            {
                return new Retorno { Sucesso = false, Mensagem = ex.Message };
            }
        }

        public Retorno AlterarCompraGado(CompraGadoWebAPI value)
        {
            try
            {
                List<CompraGadoItem> _LstCompraGadoItem = new List<CompraGadoItem>();

                foreach (CompraGadoItemWebAPI _CompraGadoItemWebAPI in value.CompraDadoItem)
                    _LstCompraGadoItem.Add(new CompraGadoItem { CompraGadoID = _CompraGadoItemWebAPI.CompraGadoID, AnimalID = _CompraGadoItemWebAPI.AnimalID, Quantidade = _CompraGadoItemWebAPI.Quantidade });

                _CompraGadoAppService.AtualizarCompra(new CompraGado { ID = value.ID, DataEntrega = value.DataEntrega, PecuaristaID = value.PecuaristaID, CompraDadoItem = _LstCompraGadoItem });

                return new Retorno { Sucesso = true };

            }
            catch (Exception ex)
            {
                return new Retorno { Sucesso = false, Mensagem = ex.Message };
            }
        }

        public Retorno ExcluirCompraGado(CompraGadoWebAPI value)
        {
            try
            {
                _CompraGadoAppService.Excluir(value.ID);

                return new Retorno { Sucesso = true };

            }
            catch (Exception ex)
            {
                return new Retorno { Sucesso = false, Mensagem = ex.Message };
            }
        }

        public List<PesquisarCompraGado> ConsultarCompraGado()
        {
            return _CompraGadoAppService.ConsultarLayoutPesquisar();
        }

        public CompraGadoWebAPI ConsultarById(string IDCompraGado)
        {
            if (long.TryParse(IDCompraGado, out long n))
            {
                CompraGado _CompraGado = _CompraGadoAppService.ConsultarById(long.Parse(IDCompraGado));

                List<CompraGadoItemWebAPI> _CompraGadoItemWebAPI = new List<CompraGadoItemWebAPI>();

                foreach (CompraGadoItem _CompraGadoItem in _CompraGado.CompraDadoItem)
                    _CompraGadoItemWebAPI.Add(new CompraGadoItemWebAPI { AnimalID = _CompraGadoItem.AnimalID, CompraGadoID = _CompraGadoItem.CompraGadoID, Quantidade = _CompraGadoItem.Quantidade });

                return new CompraGadoWebAPI { ID = _CompraGado.ID, CompraDadoItem = _CompraGadoItemWebAPI, DataEntrega = _CompraGado.DataEntrega, PecuaristaID = _CompraGado.PecuaristaID };
            }
            else
                return null;
        }
    }
}
