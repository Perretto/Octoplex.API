using CK.Produtos.Domain.Produtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Produtos.Web.Application.Features.Produtos.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Codigo)
                .NotEmpty()
                .WithMessage("Preecha o código do produto");

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("Preecha a descrição do produto");
        }
    }
}
