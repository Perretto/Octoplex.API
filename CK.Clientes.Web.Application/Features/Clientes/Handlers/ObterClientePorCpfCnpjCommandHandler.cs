using Octoplex.Clientes.Domain.Clientes;
using Octoplex.Clientes.Web.Application.Features.Clientes.Commands;
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
    //public class ObterClientePorCpfCnpjCommandHandler : IRequestHandler<ClienteListarPorCpfCnpjQuery, Cliente>
    //{
    //    private readonly IClientesRepository _clientesRepository;
    //    public ObterClientePorCpfCnpjCommandHandler(IClientesRepository clientesRepository)
    //    {
    //        _clientesRepository = clientesRepository;
    //    }
    //    public async Task<Cliente> Handle(ClienteListarPorCpfCnpjQuery request, CancellationToken cancellationToken)
    //    {
    //        var cliente = await Task.FromResult(_clientesRepository.ObterPorCPFCNPJ(request.CpfCnpj));
    //        if (cliente.IsFaulted)
    //        {
    //            return null;
    //        }
    //        return cliente.Result.Success;
    //    }
    //}
}
