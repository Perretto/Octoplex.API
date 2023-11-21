using Octoplex.Produtos.Domain.Produtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Web.Application.Features.Produtos.Queries
{
    public class ProdutoListarPorIdQuery : IRequest<Produto>
    {
        public int Id { get; set; }
    }
}
