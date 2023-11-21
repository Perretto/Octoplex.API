using Octoplex.Kernel;
using Octoplex.Pedidos.Domain.Pedidos;
using Octoplex.Pedidos.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Infra.Data.Pedidos
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly PedidoDbContext _context;
        public PedidosRepository(PedidoDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Exception, Pedido>> Adicionar(Pedido pedido)
        {
            _context.Add(pedido);
            var pedidoNovo = await _context.SaveChangesAsync();
            var pedidoAdicionado = Result<Exception, Pedido>.Of(pedido);
            if (pedidoAdicionado.IsFailure)
            {
                return pedidoAdicionado.Failure;
            }
            return pedido;
        }

        public Result<Exception, IQueryable<Pedido>> Listar()
        {
            var listaPedidos = _context.Pedidos;
            if (!listaPedidos.Any())
            {
                return new Result<Exception, IQueryable<Pedido>>();
            }
            return listaPedidos;
        }

        public async Task<Result<Exception, Pedido>> ObterPorNumeroPedidoAsync(string numeroPedido)
        {
            var pedido = await _context.Pedidos.FindAsync(numeroPedido);
            var resultValidation = Result<Exception, Pedido>.Of(pedido);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return pedido;
        }

        public async Task<Result<Exception, Pedido>> ObterPorPedidoIdAsync(Guid Id)
        {
            var pedido = await _context.Pedidos.FindAsync(Id);
            var resultValidation = Result<Exception, Pedido>.Of(pedido);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return pedido;
        }
    }
}
