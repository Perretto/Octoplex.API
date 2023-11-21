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
    public class ProdutoListarPorNcmCommandHandler : IRequestHandler<ProdutoListarPorNcmQuery, IQueryable<Produto>>
    {
        private readonly IProdutosRepository _produtosRepository;
        public ProdutoListarPorNcmCommandHandler(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public async Task<IQueryable<Produto>> Handle(ProdutoListarPorNcmQuery request, CancellationToken cancellationToken)
        {
            var products = await Task.FromResult(_produtosRepository.ListarPorNcm(request.NCM));
            if (products.IsFailure)
            {
                return null;
            }
            return products.Success.AsQueryable();
        }
    }
}
