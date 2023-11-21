using Octoplex.Pedidos.Domain.Pedidos;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Commands;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Handlers
{
    public class ListarPedidoCommandHandler : IRequestHandler<PedidoListarQuery, IQueryable<Pedido>>
    {
        private readonly IPedidosRepository _pedidosRepository;
        public ListarPedidoCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }
        public async Task<IQueryable<Pedido>> Handle(PedidoListarQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_pedidosRepository.Listar());
            if (result.IsFailure)
            {
                return null;
            }
            return result.Success;
        }
    }
}
