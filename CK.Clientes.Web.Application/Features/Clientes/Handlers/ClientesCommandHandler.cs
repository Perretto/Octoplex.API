using Octoplex.Clientes.Domain.Clientes;
using Octoplex.Clientes.Web.Application.Features.Clientes.Commands;
using Octoplex.Clientes.Web.Application.Features.Clientes.Queries;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Web.Application.Features.Clientes.Handlers
{
    public class ClientesCommandHandler
        : IRequestHandler<ClienteCommand, Cliente>
        , IRequestHandler<ClienteAtualizadoCommand, Cliente>
        , IRequestHandler<ClienteListarQuery, IQueryable<Cliente>>
        , IRequestHandler<ClienteListarPorCepQuery, IQueryable<Cliente>>
        , IRequestHandler<ClienteListarPorIdQuery, Cliente>
        , IRequestHandler<ClienteListarPorCpfCnpjQuery, Cliente>
    {
        private readonly IClientesRepository _clientesRepository;
        public ClientesCommandHandler(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        /// <summary>
        /// Adiciona um cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Cliente> Handle(ClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_clientesRepository.Adicionar(request.Cliente));
            if (result.IsFaulted)
            {
                return null;
            }
            return result.Result.Success;
        }

        /// <summary>
        /// Atualiza um cliente especifico
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Cliente> Handle(ClienteAtualizadoCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_clientesRepository.Atualizar(request.Cliente));
            if (result.IsFaulted)
            {
                return null;
            }
            return result.Result.Success;
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IQueryable<Cliente>> Handle(ClienteListarQuery request, CancellationToken cancellationToken)
        {
            var clientes = await Task.FromResult(_clientesRepository.Listar());
            if (clientes.IsFailure)
            {
                return null;
            }
            return clientes.Success;
        }

        /// <summary>
        /// Lista os clientes por CEP
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IQueryable<Cliente>> Handle(ClienteListarPorCepQuery request, CancellationToken cancellationToken)
        {
            var clients = await Task.FromResult(_clientesRepository.ListaClientesPorCep(request.Cep));
            if (clients.IsFailure)
            {
                return null;
            }
            return clients.Success.AsQueryable();
        }

        /// <summary>
        /// Lista os clientes por ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Cliente> Handle(ClienteListarPorIdQuery request, CancellationToken cancellationToken)
        {
            var clientes = await Task.FromResult(_clientesRepository.ObterPorIdAsync(request.Id));
            if (clientes.IsFaulted)
            {
                return null;
            }
            return clientes.Result.Success;
        }

        /// <summary>
        /// Lista os clientes por CPF/CNPJ
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Cliente> Handle(ClienteListarPorCpfCnpjQuery request, CancellationToken cancellationToken)
        {
            var cliente = await Task.FromResult(_clientesRepository.ObterPorCPFCNPJ(request.CpfCnpj));
            if (cliente.IsFaulted)
            {
                return null;
            }
            return cliente.Result.Success;
        }
    }
}
