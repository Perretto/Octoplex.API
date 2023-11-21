using Octoplex.Pedidos.Domain.Pedidos;
using MediatR;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Queries
{
    public class PedidoListarPorNumeroQuery : IRequest<Pedido>
    {
        public string numeroPedido { get; set; }
    }
}
