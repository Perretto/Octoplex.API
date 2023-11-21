using Octoplex.Produtos.Domain.Produtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Web.Application.Features.Produtos.Commands
{
    public class ExcluirProdutoCommand: IRequest<Produto>
    {
        public ExcluirProdutoCommand(int id)
        {
            //Produto = produto;
            Id = id;//produto.Id;
        }
        public Produto Produto { get; set; }
        public int Id { get; set; }
    }
}
