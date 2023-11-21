using Octoplex.Pedidos.Domain.Pedidos;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Handlers
{
    public class ListarPedidoPorIdCommandHandler : IRequestHandler<PedidoListarPorIdQuery, Pedido>
    {
        private readonly IPedidosRepository _pedidosRepository;
        public ListarPedidoPorIdCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }
        public async Task<Pedido> Handle(PedidoListarPorIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_pedidosRepository.ObterPorPedidoIdAsync(request.Id));
            if (result.IsFaulted)
            {
                return null;
            }
            return result.Result.Success;
        }
    }
}
