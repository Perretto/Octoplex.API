using Octoplex.Clientes.Domain.Clientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Web.Application.Features.Clientes.Commands
{
    public class ClienteAtualizadoCommand: IRequest<Cliente>
    {
        public ClienteAtualizadoCommand(Cliente cliente)
        {
            Cliente = cliente;
        }
        public Cliente Cliente { get; set; }
    }
}
