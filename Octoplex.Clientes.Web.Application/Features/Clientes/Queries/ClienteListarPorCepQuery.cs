using Octoplex.Clientes.Domain.Clientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Web.Application.Features.Clientes.Queries
{
    public class ClienteListarPorCepQuery : IRequest<IQueryable<Cliente>>
    {
        public string Cep { get; set; }
    }
}
