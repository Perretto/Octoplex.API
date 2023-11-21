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
    //public class ListarClientePorCepCommandHandler : IRequestHandler<ClienteListarPorCepQuery, IQueryable<Cliente>>
    //{
    //    private readonly IClientesRepository _clientesRepository;
    //    public ListarClientePorCepCommandHandler(IClientesRepository clientesRepository)
    //    {
    //        _clientesRepository = clientesRepository;
    //    }

    //    public async Task<IQueryable<Cliente>> Handle(ClienteListarPorCepQuery request, CancellationToken cancellationToken)
    //    {
    //        var clients = await Task.FromResult(_clientesRepository.ListaClientesPorCep(request.Cep));
    //        if (clients.IsFailure)
    //        {
    //            return null;
    //        }
    //        return clients.Success.AsQueryable();
    //    }

    //}
}
