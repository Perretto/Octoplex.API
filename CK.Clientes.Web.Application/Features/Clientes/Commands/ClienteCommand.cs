using Octoplex.Clientes.Domain.Clientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Web.Application.Features.Clientes.Commands
{
    public class ClienteCommand : IRequest<Cliente>
    {
        public ClienteCommand(Cliente cliente)
        {
            Cliente = cliente;
            CPFCnpj = cliente.CnpjCpf;
        }

        public Cliente Cliente { get; set; }
        public string CPFCnpj { get; set; }
    }
}
