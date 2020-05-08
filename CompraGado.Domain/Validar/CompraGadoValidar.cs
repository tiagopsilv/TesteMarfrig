using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Repository;
using SistemaCompraGado.Domain.Interfaces.Validar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SistemaCompraGado.Domain.Validar
{
    public class CompraGadoValidar : ICompraGadoValidar
    {

        private readonly ICompraGadoRepository _CompraGadoRepository;

        public CompraGadoValidar(ICompraGadoRepository CompraGadoRepository)
        {
            _CompraGadoRepository = CompraGadoRepository;
        }

        public bool ValidarCompraGado(CompraGado Compra)
        {

            bool retorno = false;

            if (!ValidarID(Compra))
                throw new System.ArgumentException("O ID informado já está em uso para outra compra", "ValidarCompra");
            else if (!ValidarDataEntrega(Compra))
                throw new System.ArgumentException("Uma compra de gado tem que ter obrigatoriamente uma data de entrega.", "ValidarCompra");
            else if (!ValidarPecuarista(Compra))
                throw new System.ArgumentException("Uma compra de gado tem que ter obrigatoriamente um pecuarista.", "ValidarCompra");
            else if (!ValidarItens(Compra.CompraDadoItem))
                throw new System.ArgumentException("Um compra de gado precisa ter no minimo um item.", "ValidarCompra");
            else if (!ValidarSeExisteDoisItensMesmoAnimal(Compra.CompraDadoItem))
                throw new System.ArgumentException("Um compra de gado não pode ter dois itens com o mesmo animal.", "ValidarCompra");
            else if (!ValidarQuantidadeItem(Compra.CompraDadoItem))
                throw new System.ArgumentException("Um item não pode ter quantidade menor do que zero.", "ValidarCompra");
            else
                retorno = true;

            return retorno;

        }

        public bool ValidarAtualizarCompraGado(CompraGado Compra)
        {
            bool retorno = false;

            if (!ValidarDataEntrega(Compra))
                throw new System.ArgumentException("Uma compra de gado tem que ter obrigatoriamente uma data de entrega.", "ValidarCompra");
            else if (!ValidarPecuarista(Compra))
                throw new System.ArgumentException("Uma compra de gado tem que ter obrigatoriamente um pecuarista.", "ValidarCompra");
            else if (!ValidarItens(Compra.CompraDadoItem))
                throw new System.ArgumentException("Um compra de gado precisa ter no minimo um item.", "ValidarCompra");
            else if (!ValidarSeExisteDoisItensMesmoAnimal(Compra.CompraDadoItem))
                throw new System.ArgumentException("Um compra de gado não pode ter dois itens com o mesmo animal.", "ValidarCompra");
            else if (!ValidarQuantidadeItem(Compra.CompraDadoItem))
                throw new System.ArgumentException("Um item não pode ter quantidade menor do que zero.", "ValidarCompra");
            else
                retorno = true;

            return retorno;
        }

        private bool ValidarID(CompraGado Compra)
        {
            return (_CompraGadoRepository.GetById(Compra.ID).DataEntrega.GetHashCode() == 0);
        }

        private bool ValidarDataEntrega(CompraGado Compra)
        {
            return (Compra.DataEntrega.GetHashCode() != 0);
        }

        private bool ValidarPecuarista(CompraGado Compra)
        {
            return (Compra.PecuaristaID.GetHashCode() != 0);
        }

        private bool ValidarItens(List<CompraGadoItem> Itens)
        {
            return Itens.Count() > 0;
        }

        private bool ValidarSeExisteDoisItensMesmoAnimal(List<CompraGadoItem> Itens)
        {
            return !Itens.GroupBy(x => x.AnimalID).Any(T => T.Count() > 1);
        }

        private bool ValidarQuantidadeItem(List<CompraGadoItem> Itens)
        {
            if (Itens.Where(x =>
                        {
                            return !Regex.IsMatch(x.Quantidade.Replace(".",""), @"^\d+$");
                        }
            ).Count() > 0)
                return false;

            return (Itens.Where(T => int.Parse(T.Quantidade.Replace(".", "")) >= 0).Count() > 0);
        }

    }
}
