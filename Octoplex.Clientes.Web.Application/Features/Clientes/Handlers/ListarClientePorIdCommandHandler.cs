using Octoplex.Clientes.Domain.Clientes;
using Octoplex.Clientes.Web.Application.Features.Clientes.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Web.Application.Features.Clientes.Handlers
{
    //public class ListarClientePorIdCommandHandler : IRequestHandler<ClienteListarPorIdQuery, Cliente>
    //{
    //    private readonly IClientesRepository _clientesRepository;
    //    public ListarClientePorIdCommandHandler(IClientesRepository clientesRepository)
    //    {
    //        _clientesRepository = clientesRepository;
    //    }
    //    public async Task<Cliente> Handle(ClienteListarPorIdQuery request, CancellationToken cancellationToken)
    //    {
    //        var clientes = await Task.FromResult(_clientesRepository.ObterPorIdAsync(request.Id));
    //        if (clientes.IsFaulted)
    //        {
    //            return null;
    //        }
    //        return clientes.Result.Success;
    //    }
    //}
}
