using Octoplex.Produtos.Domain.Produtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Web.Application.Features.Produtos.Commands
{
    public class ProdutoCommand : IRequest<Produto>
    {
        public ProdutoCommand(Produto produto)
        {
            Produto = produto;
        }
        public Produto Produto { get; set; }
    }
}
