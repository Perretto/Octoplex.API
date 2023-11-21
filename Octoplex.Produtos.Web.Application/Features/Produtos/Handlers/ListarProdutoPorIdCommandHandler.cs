using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Web.Application.Features.Produtos.Handlers
{
    public class ListarProdutoPorIdCommandHandler : IRequestHandler<ProdutoListarPorIdQuery, Produto>
    {
        private readonly IProdutosRepository _produtosRepository;
        public ListarProdutoPorIdCommandHandler(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
        public async Task<Produto> Handle(ProdutoListarPorIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_produtosRepository.ObterPorIdAsync(request.Id));
            if (result.IsFaulted)
            {
                return null;
            }
            return result.Result.Success;
        }
    }
}
