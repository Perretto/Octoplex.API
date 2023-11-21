using Octoplex.Pedidos.Domain.Pedidos;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Handlers
{
    public class ListarPedidoPorNumeroCommandHandler : IRequestHandler<PedidoListarPorNumeroQuery, Pedido>
    {
        private readonly IPedidosRepository _pedidosRepository;
        public ListarPedidoPorNumeroCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public async Task<Pedido> Handle(PedidoListarPorNumeroQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_pedidosRepository.ObterPorNumeroPedidoAsync(request.numeroPedido));
            if (result.IsFaulted)
            {
                return null;
            }
            return result.Result.Success;
        }
    }
}
