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
    //public class AtualizarClienteCommandHandler : IRequestHandler<ClienteAtualizadoCommand, Cliente>
    //{
    //    private readonly IClientesRepository _clientesRepository;
    //    public AtualizarClienteCommandHandler(IClientesRepository clientesRepository)
    //    {
    //        _clientesRepository = clientesRepository;
    //    }

    //    public async Task<Cliente> Handle(ClienteAtualizadoCommand request, CancellationToken cancellationToken)
    //    {
    //        var result = await Task.FromResult(_clientesRepository.Atualizar(request.Cliente));
    //        if (result.IsFaulted)
    //        {
    //            return null;
    //        }
    //        return result.Result.Success;
    //    }
    //}
}
