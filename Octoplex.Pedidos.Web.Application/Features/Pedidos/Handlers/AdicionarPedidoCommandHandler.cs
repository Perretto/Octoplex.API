using Octoplex.Pedidos.Domain.Pedidos;
using Octoplex.Pedidos.Web.Application.Features.Pedidos.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Handlers
{
    public class AdicionarPedidoCommandHandler : IRequestHandler<PedidoCommand, Pedido>
    {
        private readonly IPedidosRepository _pedidosRepository;
        public AdicionarPedidoCommandHandler(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public Task<Pedido> Handle(PedidoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
