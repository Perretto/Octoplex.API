using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Web.Application.Features.Produtos.Handlers
{
    public class AtualizarProdutoCommandHandler : IRequestHandler<ProdutoAtualizadoCommand, Produto>
    {
        private readonly IProdutosRepository _produtosRepository;
        public AtualizarProdutoCommandHandler(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
        public async Task<Produto> Handle(ProdutoAtualizadoCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_produtosRepository.Atualizar(request.Produto));
            if (result.IsFaulted)
            {
                return new Produto();
            }
            return result.Result.Success;
        }
    }
}
