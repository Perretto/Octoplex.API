using Octoplex.Clientes.Domain.Clientes;
using Octoplex.Empresas.Domain.Empresas;
using Octoplex.Kernel;
using Octoplex.WebAPI.Features.Clientes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Octoplex.Clientes.Web.Application.Features.Clientes.Queries;
using Octoplex.Clientes.Web.Application.Features.Clientes.Commands;

namespace Octoplex.Clientes
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly IMediator _mediator;
        public ClientesController(IClientesRepository clientesRepository, IMediator mediator)
        {
            _clientesRepository = clientesRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// EndPoint responsável por listar todos clientes
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        [ProducesResponseType(typeof(ListClientesViewModel), StatusCodes.Status200OK)]
        [Route("listar")]
        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            try
            {
                var getClientes = new ClienteListarQuery();
                var result = await Task.FromResult(_mediator.Send(getClientes));
                if (result.Result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// EndPoint responsável por obter um cliente pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Cliente</returns>
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClientByIdAsync(Guid id)
        {
            var cliente = new ClienteListarPorIdQuery
            {
                Id = id
            };
            var result = await Task.FromResult(_mediator.Send(cliente));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint responsável por atualizar um cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Cliente</returns>
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> AtualizarCliente([FromBody] Cliente cliente)
        {
            var clienteAtualizado = new ClienteAtualizadoCommand(cliente);
            var result = await Task.FromResult(_mediator.Send(clienteAtualizado));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint responsável por excluir um cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirCliente(Cliente cliente)
        {
            var clienteExcluido = new ClienteCommand(cliente);
            var result = await Task.FromResult(_mediator.Send(cliente));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint responsável por adicionar um cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Cliente</returns>
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AdicionarCliente([FromBody] Cliente cliente)
        {
            var clienteAdicionado = new ClienteCommand(cliente);
            var result = await Task.FromResult(_mediator.Send(clienteAdicionado));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint Responsável por obter um cliente por CPF ou CNPJ
        /// </summary>
        /// <param name="CpfCnpj"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [Route("cpfcnpj")]
        [HttpGet]
        public async Task<IActionResult> ObterClientePorCpfCnpj(string CpfCnpj)
        {
            var clienteCPFCnpj = new ClienteListarPorCpfCnpjQuery
            {
                CpfCnpj = CpfCnpj
            };
            var result = await Task.FromResult(_mediator.Send(clienteCPFCnpj));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// Lista os clientes por um determiado CEP
        /// </summary>
        /// <param name="Cep"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [Route("cep")]
        [HttpGet]
        public async Task<IActionResult> ListarClientesPorCep(string Cep)
        {
            var ClientCep = new ClienteListarPorCepQuery
            {
                Cep = Cep
            };

            var result = await Task.FromResult(_mediator.Send(ClientCep));
            if(result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);

        }

    }
}
