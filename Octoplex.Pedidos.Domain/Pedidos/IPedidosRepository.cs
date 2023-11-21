using Octoplex.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Domain.Pedidos
{
    public interface IPedidosRepository
    {
        Task<Result<Exception, Pedido>> Adicionar(Pedido pedido);
        Result<Exception, IQueryable<Pedido>> Listar();
        Task<Result<Exception, Pedido>> ObterPorPedidoIdAsync(Guid Id);
        Task<Result<Exception, Pedido>> ObterPorNumeroPedidoAsync(string numeroPedido);
    }
}
