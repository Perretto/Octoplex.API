using Octoplex.Pedidos.Domain.Pedidos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Queries
{
    public class PedidoListarQuery : IRequest<IQueryable<Pedido>>
    {

    }
}
