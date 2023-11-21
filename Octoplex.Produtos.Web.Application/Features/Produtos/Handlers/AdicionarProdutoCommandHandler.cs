using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Web.Application.Features.Produtos.Handlers
{
    public class AdicionarProdutoCommandHandler : IRequestHandler<ProdutoCommand, Produto>
    {
        private readonly IProdutosRepository _produtosRepository;
        public AdicionarProdutoCommandHandler(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
        public async Task<Produto> Handle(ProdutoCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_produtosRepository.Adicionar(request.Produto));
            if (result.IsFaulted)
            {
                return new Produto();
            }
            return result.Result.Success;
        }
    }
}
