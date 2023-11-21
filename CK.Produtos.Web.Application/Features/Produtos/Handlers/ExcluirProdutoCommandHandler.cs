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
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, Produto>
    {
        private readonly IProdutosRepository _produtosRepository;
        public ExcluirProdutoCommandHandler(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
        public async Task<Produto> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_produtosRepository.Excluir(request.Id));
            if (result.IsFaulted)
            {
                return new Produto();
            }
            return result.Result.Success;
        }
    }
}
