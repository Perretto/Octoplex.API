using Octoplex.Pedidos.Domain.Pedidos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Web.Application.Features.Pedidos.Commands
{
    public class PedidoCommand : IRequest<Pedido>
    {
        public PedidoCommand(Pedido pedido)
        {
            Pedido = pedido;
        }
        public Pedido Pedido { get; set; }
    }
}
