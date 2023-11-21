using Octoplex.Kernel;
using Octoplex.Pedidos.Domain.Pedidos;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Commands;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Queries;
using Octoplex.Pedidos.WebAPI.Features.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.WebAPI.Features.Pedidos
{
    /// <summary>
    /// Controlador de Pedidos
    /// Responsável por prover os dados relacionado a pedidos
    /// </summary>
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidosRepository _pedidosRepository;
        private IMediator _mediator;
        public PedidoController(IPedidosRepository pedidosRepository, IMediator mediator)
        {
            _pedidosRepository = pedidosRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// EndPoint responsável por adicionar um pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>Pedido</returns>
        [ProducesResponseType(typeof(PedidoViewModel), StatusCodes.Status200OK)]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AdicionarPedido(Pedido pedido)
        {
            var pedidoAdicionado = new PedidoCommand(pedido);
            var result = await Task.FromResult(_mediator.Send(pedidoAdicionado));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint responsável por listar todos os pedidos
        /// </summary>
        /// <returns>Lista de Pedidos</returns>
        [ProducesResponseType(typeof(ListPedidosViewModel), StatusCodes.Status200OK)]
        [Route("listar")]
        [HttpGet]
        public async Task<IActionResult> ListarPedido()
        {
            var pedidos = new PedidoListarQuery();
            var result = await Task.FromResult(_mediator.Send(pedidos));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        /// <summary>
        /// EndPoint responsável por obter uma pedido pelo numero do pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pedido</returns>
        [ProducesResponseType(typeof(PedidoViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById(Guid id)
        {
            var pedidoId = new PedidoListarPorIdQuery 
            { 
                Id = id 
            };
            var result = await Task.FromResult(_mediator.Send(pedidoId));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);
        }

    }
}
