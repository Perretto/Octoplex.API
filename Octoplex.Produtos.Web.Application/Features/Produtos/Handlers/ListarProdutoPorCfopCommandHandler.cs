using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Queries;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Web.Application.Features.Produtos.Handlers
{
    public class ListarProdutoPorCfopCommandHandler : IRequestHandler<ProdutoListarPorCfopQuery, IQueryable<Produto>>
    {
        private readonly IProdutosRepository _produtosRepository;
        public ListarProdutoPorCfopCommandHandler(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public async Task<IQueryable<Produto>> Handle(ProdutoListarPorCfopQuery request, CancellationToken cancellationToken)
        {
            var product = await Task.FromResult(_produtosRepository.ListarPorCfop(request.Cfop));
            if (product.IsFailure)
            {
                return null;
            }
            return product.Success;
        }
    }
}
