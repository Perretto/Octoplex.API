using Octoplex.Clientes.Domain.Clientes;
using Octoplex.Clientes.Web.Application.Features.Clientes.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Web.Application.Features.Clientes.Handlers
{
    //public class AdicionarClienteCommandHandler : IRequestHandler<ClienteCommand, Cliente>
    //{
    //    private readonly IClientesRepository _clientesRepository;
    //    public AdicionarClienteCommandHandler(IClientesRepository clientesRepository)
    //    {
    //        _clientesRepository = clientesRepository;
    //    }
    //    public async Task<Cliente> Handle(ClienteCommand request, CancellationToken cancellationToken)
    //    {
    //        var result = await Task.FromResult(_clientesRepository.Adicionar(request.Cliente));
    //        if (result.IsFaulted)
    //        {
    //            return null;
    //        }
    //        return result.Result.Success;
    //    }
    //}
}
