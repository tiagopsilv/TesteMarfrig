using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaCompraGado.Application.Entities;
using SistemaCompraGado.Application.Interfaces;
using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Services.Models;
using SistemaCompraGado.Services.Models.Entities;
using SistemaCompraGado.Services.Models.Interfaces;

namespace SistemaCompraGado.Services.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar das funções GET/POST de Compra de Gado.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompraGadoController : ControllerBase
    {
        private readonly IPecuaristaAppService _PecuaristaAppService;
        private readonly IAnimalAppService _AnimalAppService;
        private readonly ICompraGadoModel _CompraGadoModel;

        public CompraGadoController(IPecuaristaAppService PecuaristaAppService, IAnimalAppService AnimalAppService, ICompraGadoModel CompraGadoModel)
        {
            _PecuaristaAppService = PecuaristaAppService;
            _AnimalAppService = AnimalAppService;
            _CompraGadoModel = CompraGadoModel;
    }

        /// <summary>
        /// Método resposável por trazer uma lista de todas a informações sobre Pecuarista.
        /// </summary>
        /// <returns>Lista de Pecuarista</returns>
        [HttpGet("GetListaPecuaristas")]
        public ActionResult<List<Pecuarista>> GetListaPecuaristas()
        {
            return _PecuaristaAppService.GetAll().ToList();
        }

        /// <summary>
        /// Método resposável por trazer uma lista de todas a informações sobre Animal.
        /// </summary>
        /// <returns>Lista de Animal</returns>
        [HttpGet("GetListaAnimal")]
        public ActionResult<List<Animal>> GetListaAnimal()
        {
            return _AnimalAppService.GetAll().ToList();
        }

        /// <summary>
        /// Efetivar a gravação de uma compra de Gado 
        /// </summary>
        /// <param name="value">Envia por body informaçãoe de compra</param>
        /// <returns>Retorna a classe do tipo Retorno</returns>
        [HttpPost("GravarCompraGado")]
        [Route("GravarCompraGado")]
        public ActionResult<Retorno> GravarCompraGado([FromBody] CompraGadoWebAPI value)
        {
            return _CompraGadoModel.InserirCompraGado(value);
        }

        /// <summary>
        /// Alterar uma compra de Gado 
        /// </summary>
        /// <param name="value">Envia por body informaçãoe de compra</param>
        /// <returns>Retorna a classe do tipo Retorno</returns>
        [HttpPost("AlterarCompraGado")]
        [Route("AlterarCompraGado")]
        public ActionResult<Retorno> AlterarCompraGado([FromBody] CompraGadoWebAPI value)
        {
            return _CompraGadoModel.AlterarCompraGado(value);
        }

        /// <summary>
        /// Método resposável por trazer uma lista de todas a informações sobre Compra de Gado.
        /// </summary>
        /// <returns>Lista de PesquisarCompraGado</returns>
        [HttpGet("GetListaCompraGado")]
        public ActionResult<List<PesquisarCompraGado>> GetListaCompraGado()
        {
            return _CompraGadoModel.ConsultarCompraGado();
        }

        /// <summary>
        /// Método resposável por trazer uma lista de todas a informações sobre Compra de Gado filtrando por ID.
        /// </summary>
        /// <returns>Retorna informações de Compra de Gado</returns>
        [HttpGet("GetListaCompraGadoByID/{ID}")]
        public ActionResult<CompraGadoWebAPI> GetListaCompraGadoByID(string ID)
        {
            return _CompraGadoModel.ConsultarById(ID);
        }

        /// <summary>
        /// Método resposável por excluir a compra de um gado.
        /// </summary>
        /// <returns>Retorna a classe do tipo Retorno</returns>
        [HttpPost("ExcluirItem")]
        [Route("ExcluirItem")]
        public ActionResult<Retorno> ExcluirItem([FromBody] CompraGadoWebAPI value)
        {
            return _CompraGadoModel.ExcluirCompraGado(value);
        }

    }
}
