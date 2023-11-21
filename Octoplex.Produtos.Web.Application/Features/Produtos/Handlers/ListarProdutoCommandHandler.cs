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
    public class ListarProdutoCommandHandler : IRequestHandler<ProdutoListarQuery, IQueryable<Produto>>
    {
        private readonly IProdutosRepository _produtosRepository;
        public ListarProdutoCommandHandler(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
        public async Task<IQueryable<Produto>> Handle(ProdutoListarQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_produtosRepository.Listar());
            if (result.IsFailure)
            {
                return null;
            }
            return result.Success;
        }
    }
}
