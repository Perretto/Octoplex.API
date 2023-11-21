using Octoplex.Pedidos.Domain.Pedidos;
using MediatR;
using System;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Queries
{
    public class PedidoListarPorIdQuery : IRequest<Pedido>
    {
       public Guid Id { get; set; }
    }
}
