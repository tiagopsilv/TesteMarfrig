using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Repository;
using SistemaCompraGado.Domain.Interfaces.Services;
using SistemaCompraGado.Domain.Interfaces.Validar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Services
{
    public class CompraGadoService : ServiceBase<CompraGado>, ICompraGadoService
    {

        private readonly ICompraGadoRepository _CompraGadoRepository;
        private readonly ICompraGadoItemRepository _CompraGadoItemRepository;
        private readonly ICompraGadoValidar _CompraGadoValidar;
        private readonly IPecuaristaRepository _PecuaristaRepository;
        private readonly IAnimalRepository _AnimalRepository;

        public CompraGadoService(ICompraGadoRepository CompraGadoRepository, ICompraGadoValidar CompraGadoValidar, ICompraGadoItemRepository CompraGadoItemRepository, IPecuaristaRepository PecuaristaRepository, IAnimalRepository AnimalRepository)
            : base(CompraGadoRepository)
        {
            _CompraGadoRepository = CompraGadoRepository;
            _CompraGadoValidar = CompraGadoValidar;
            _CompraGadoItemRepository = CompraGadoItemRepository;
            _PecuaristaRepository = PecuaristaRepository;
            _AnimalRepository = AnimalRepository;
        }

        public CompraGado AdicionarCompra(CompraGado Compra)
        {
            var retorno = new CompraGado();

            if (_CompraGadoValidar.ValidarCompraGado(Compra))
            {
                _CompraGadoRepository.Add(Compra);

                foreach (CompraGadoItem Item in Compra.CompraDadoItem)
                    _CompraGadoItemRepository.Add(new CompraGadoItem { AnimalID = Item.AnimalID, CompraGadoID = Compra.ID, Quantidade = Item.Quantidade });

                retorno = ConsultarById(Compra.ID);
            }
            else
                throw new System.ArgumentException("Não foi possível efetivar a compra", "AdicionarCompra");

            return retorno;
        }

        public CompraGado AtualizarCompra(CompraGado Compra)
        {
            var retorno = new CompraGado();

            if (_CompraGadoValidar.ValidarAtualizarCompraGado(Compra))
            {
                _CompraGadoRepository.Update(Compra);

                _CompraGadoItemRepository.RemoveCompraGadoId(Compra.ID);

                foreach (CompraGadoItem Item in Compra.CompraDadoItem)
                    _CompraGadoItemRepository.Add(new CompraGadoItem { AnimalID = Item.AnimalID, CompraGadoID = Compra.ID, Quantidade = Item.Quantidade });


                retorno = ConsultarById(Compra.ID);
            }
            else
                throw new System.ArgumentException("Não foi possível atualizar a compra", "AdicionarCompra");

            return retorno;
        }

            public List<CompraGado> Consultar()
        {
            List<CompraGado> _LstCompraGado = _CompraGadoRepository.GetAll();

            foreach (CompraGado _Compra in _LstCompraGado)
            {
                _Compra.CompraDadoItem = _CompraGadoItemRepository.GetByCompraGadoId(_Compra.ID);
                _Compra.Pecuarisa = _PecuaristaRepository.GetById(_Compra.PecuaristaID);
                foreach (CompraGadoItem _CompraGadoItem in _Compra.CompraDadoItem)
                {
                    _CompraGadoItem.Animal = _AnimalRepository.GetById(_CompraGadoItem.AnimalID);
                    _CompraGadoItem.CompraGado = _Compra;
                }
            }

            return _LstCompraGado;
        }

        public CompraGado ConsultarById(long IDCompraGado)
        {
            CompraGado _CompraGado = _CompraGadoRepository.GetById(IDCompraGado);

            _CompraGado.CompraDadoItem = _CompraGadoItemRepository.GetByCompraGadoId(IDCompraGado);
            _CompraGado.Pecuarisa = _PecuaristaRepository.GetById(_CompraGado.PecuaristaID);
            foreach (CompraGadoItem _CompraGadoItem in _CompraGado.CompraDadoItem)
            {
                _CompraGadoItem.Animal = _AnimalRepository.GetById(_CompraGadoItem.AnimalID);
                _CompraGadoItem.CompraGado = _CompraGado;
            }

            return _CompraGado;
        }

        public CompraGado ExcluirCompra(long IDCompraGado)
        {
            _CompraGadoItemRepository.RemoveCompraGadoId(IDCompraGado);
            _CompraGadoRepository.Remove(new CompraGado { ID = IDCompraGado });

            return ConsultarById(IDCompraGado);
        }
    }
}
