using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Infra.Data.Contexto;
using SistemaCompraGado.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using SistemaCompraGado.Domain.Validar;
using SistemaCompraGado.Application;
using SistemaCompraGado.Domain.Services;

namespace XTest
{
    public class SistemaGadoTeste
    {
        [Fact]
        public void InserirAnimalData()
        {

            AnimalRepository AnimalRep = new AnimalRepository(new SistemaCompraGadoDGContexto());
            Animal _Animal = new Animal();
            _Animal.Descricao = "Mimoza";
            _Animal.Preco = "1,00";

            AnimalRep.Add(_Animal);
        }

        [Fact]
        public void SelecionarAnimalData()
        {

            AnimalRepository AnimalRep = new AnimalRepository(new SistemaCompraGadoDGContexto());
            List<Animal> LstAnimal = AnimalRep.GetAll();

        }

        [Fact]
        public void SelecionarAnimalPeloIDData()
        {

            AnimalRepository AnimalRep = new AnimalRepository(new SistemaCompraGadoDGContexto());
            Animal AnimalTeste = AnimalRep.GetById(1);

        }

        [Fact]
        public void AtualizaAnimalData()
        {

            AnimalRepository AnimalRep = new AnimalRepository(new SistemaCompraGadoDGContexto());
            Animal _Animal = new Animal();
            Animal LstAnimal = (Animal)AnimalRep.GetAll().First();
            _Animal.ID = LstAnimal.ID;
            _Animal.Descricao = "Teste 2";
            _Animal.Preco = "2,00";

            AnimalRep.Update(_Animal);

        }

        [Fact]
        public void InserirPecuaristaData()
        {

            SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository PecuaristaRep = new SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository(new SistemaCompraGadoDGContexto());
            Pecuarista _Pecuarista = new Pecuarista();
            _Pecuarista.Nome = "Teste 2";

            PecuaristaRep.Add(_Pecuarista);
        }

        [Fact]
        public void SelecionarPecuaristaData()
        {
            SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository PecuaristaRep = new SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository(new SistemaCompraGadoDGContexto());
            List<Pecuarista> LstAnimal = PecuaristaRep.GetAll();

        }

        [Fact]
        public void AtualizaPecuaristaData()
        {

            SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository PecuaristaRep = new SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository(new SistemaCompraGadoDGContexto());
            Pecuarista _Pecuarista = new Pecuarista();
            Pecuarista LstPecuarista = (Pecuarista)PecuaristaRep.GetAll().First();
            _Pecuarista.ID = LstPecuarista.ID;
            _Pecuarista.Nome = "Teste 2";

            PecuaristaRep.Update(_Pecuarista);

        }

        [Fact]
        public void InserirCompraGadoData()
        {

            CompraGadoRepository CompraGadoRep = new CompraGadoRepository(new SistemaCompraGadoDGContexto());
            CompraGado _CompraGado = new CompraGado();
            _CompraGado.ID = 203;
            _CompraGado.DataEntrega  = DateTime.Now;
            _CompraGado.PecuaristaID = 1;

            CompraGadoRep.Add(_CompraGado);
        }

        [Fact]
        public void SelecionarCompraGadoData()
        {
            CompraGadoRepository CompraGadoRep = new CompraGadoRepository(new SistemaCompraGadoDGContexto());
            List<CompraGado> LstAnimal = CompraGadoRep.GetAll();

        }

        [Fact]
        public void AtualizaCompraGadoData()
        {

            CompraGadoRepository CompraGadoRep = new CompraGadoRepository(new SistemaCompraGadoDGContexto());
            CompraGado _CompraGado = new CompraGado();
            CompraGado LstCompraGado = (CompraGado)CompraGadoRep.GetAll().First();
            _CompraGado.DataEntrega = DateTime.Now;
            _CompraGado.PecuaristaID = 1;

            CompraGadoRep.Update(_CompraGado);

        }

        [Fact]
        public void InserirCompraGadoItemDataItem()
        {

            CompraGadoItemRepository CompraGadoItemRep = new CompraGadoItemRepository(new SistemaCompraGadoDGContexto());
            CompraGadoItem _CompraGadoItem = new CompraGadoItem();
            _CompraGadoItem.Quantidade = "50";
            _CompraGadoItem.CompraGadoID = 203;
            _CompraGadoItem.AnimalID = 1;

            CompraGadoItemRep.Add(_CompraGadoItem);
        }

        [Fact]
        public void SelecionarCompraGadoItemDataItem()
        {
            CompraGadoItemRepository CompraGadoItemRep = new CompraGadoItemRepository(new SistemaCompraGadoDGContexto());
            List<CompraGadoItem> LstAnimal = CompraGadoItemRep.GetAll();

        }

        [Fact]
        public void AtualizaCompraGadoItemDataItem()
        {

            CompraGadoItemRepository CompraGadoItemRep = new CompraGadoItemRepository(new SistemaCompraGadoDGContexto());
            CompraGadoItem _CompraGadoItem = new CompraGadoItem();
            CompraGadoItem LstCompraGadoItem = (CompraGadoItem)CompraGadoItemRep.GetAll().First();
            _CompraGadoItem.Quantidade = "60";
            _CompraGadoItem.CompraGadoID = 1;
            _CompraGadoItem.AnimalID = 1;

            CompraGadoItemRep.Update(_CompraGadoItem);

        }

        [Fact]
        public void ValidarCompraGado()
        {

            CompraGadoValidar CompraGadoItemRep = new CompraGadoValidar(new CompraGadoRepository(new SistemaCompraGadoDGContexto()));
            CompraGado _CompraGado = new CompraGado();
            List<CompraGadoItem> _Itens = new List<CompraGadoItem>();

            SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository PecuaristaRep = new SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository(new SistemaCompraGadoDGContexto());
            Pecuarista LstPecuarista = (Pecuarista)PecuaristaRep.GetAll().First();
            AnimalRepository AnimalRep = new AnimalRepository(new SistemaCompraGadoDGContexto());
            Animal LstAnimal = (Animal)AnimalRep.GetAll().First();


            _CompraGado.ID = 205;

            _Itens.Add(new CompraGadoItem { AnimalID = LstAnimal.ID, CompraGadoID = _CompraGado.ID, Quantidade = "1.000" });
            // _Itens.Add(new CompraGadoItem { AnimalID = LstAnimal.ID, CompraGadoID = _CompraGado.ID, Quantidade = "1.000" });

            _CompraGado.DataEntrega = DateTime.Now;
            _CompraGado.PecuaristaID = LstPecuarista.ID;
            _CompraGado.CompraDadoItem = _Itens;

            CompraGadoItemRep.ValidarCompraGado(_CompraGado);

        }

        [Fact]
        public void ValidarCompraGadoAppService()
        {
            CompraGadoAppService CompraService = new CompraGadoAppService(new CompraGadoService(new CompraGadoRepository(new SistemaCompraGadoDGContexto()), new CompraGadoValidar(new CompraGadoRepository(new SistemaCompraGadoDGContexto())), new CompraGadoItemRepository((new SistemaCompraGadoDGContexto())), new PecuaristaRepository((new SistemaCompraGadoDGContexto())), new AnimalRepository(new SistemaCompraGadoDGContexto())));
            CompraGado Compra = new CompraGado();
            SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository PecuaristaRep = new SistemaCompraGado.Infra.Data.Repositories.PecuaristaRepository(new SistemaCompraGadoDGContexto());
            Pecuarista LstPecuarista = (Pecuarista)PecuaristaRep.GetAll().First();
            List<CompraGadoItem> _Itens = new List<CompraGadoItem>();
            AnimalRepository AnimalRep = new AnimalRepository(new SistemaCompraGadoDGContexto());
            Animal LstAnimal = (Animal)AnimalRep.GetAll().First();

            Compra.ID = 545;
            Compra.DataEntrega = DateTime.Now;
            Compra.PecuaristaID = LstPecuarista.ID;

            _Itens.Add(new CompraGadoItem { AnimalID = LstAnimal.ID, CompraGadoID = 544, Quantidade = "1.000" });

            Compra.CompraDadoItem = _Itens;

            CompraService.AdicionarCompra(Compra);
        }

        [Fact]
        public void PesquisarGadoAppService()
        {
            CompraGadoAppService CompraService = new CompraGadoAppService(new CompraGadoService(new CompraGadoRepository(new SistemaCompraGadoDGContexto()), new CompraGadoValidar(new CompraGadoRepository(new SistemaCompraGadoDGContexto())), new CompraGadoItemRepository((new SistemaCompraGadoDGContexto())), new PecuaristaRepository((new SistemaCompraGadoDGContexto())), new AnimalRepository(new SistemaCompraGadoDGContexto())));
            CompraService.Consultar();
        }

        [Fact]
        public void PesquisarLayoutGadoAppService()
        {
            CompraGadoAppService CompraService = new CompraGadoAppService(new CompraGadoService(new CompraGadoRepository(new SistemaCompraGadoDGContexto()), new CompraGadoValidar(new CompraGadoRepository(new SistemaCompraGadoDGContexto())), new CompraGadoItemRepository((new SistemaCompraGadoDGContexto())), new PecuaristaRepository((new SistemaCompraGadoDGContexto())), new AnimalRepository(new SistemaCompraGadoDGContexto())));
            CompraService.ConsultarLayoutPesquisar();
        }

    }
}
