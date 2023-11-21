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
    //public class ListarClienteCommandHandler : IRequestHandler<ClienteListarQuery, IQueryable<Cliente>>
    //{
    //    private readonly IClientesRepository _clientesRepository;
    //    public ListarClienteCommandHandler(IClientesRepository clientesRepository)
    //    {
    //        _clientesRepository = clientesRepository;
    //    }
    //    public async Task<IQueryable<Cliente>> Handle(ClienteListarQuery request, CancellationToken cancellationToken)
    //    {
    //        var clientes = await Task.FromResult(_clientesRepository.Listar());
    //        if (clientes.IsFailure)
    //        {
    //            return null;
    //        }
    //        return clientes.Success;
    //    }
    //}
}
