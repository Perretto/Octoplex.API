using Octoplex.Produtos.Domain.Produtos;
using FluentValidation;

namespace Octoplex.Produtos.WebAPI.Features.Produtos.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            //Validando o código do produto
            RuleFor(p => p.Codigo)
                .NotNull()
                .NotEmpty()
                .Length(1, 25)
                .WithMessage("Preecha o código do produto (Min 1, Max 25 caracteres)");
            
            //Validando a descrição do produto
            RuleFor(p => p.Descricao)
                .NotNull()
                .NotEmpty()
                .Length(3, 120)
                .WithMessage("Preecha a descrição do produto (Min 3 e Max 120 Caracteres");

            //Validando valor de compra
            RuleFor(p => p.Vrcompra)
                .NotEmpty()
                .Must(F_ValidaValores) //Validação customizada
                .GreaterThan(0) //Maior que zero
                .WithMessage("Informe o valor de compra (Maior que zero)");

            //Validando valor de venda
            RuleFor(p => p.Vrvista)
                .NotEmpty()
                .GreaterThan(0) //Maior que zero
                .WithMessage("Informe o valor de venda (Maior que zero)");

            //Validando grupo/categoria
            //RuleFor(p => p.CodGru)
            //    .NotEmpty()
            //    .WithMessage("Informe o grupo/categoria");

            //Validando unidade de medida
            RuleFor(p => p.Un)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe a unidade de medida do produto");


        }

        //Validação customizada
        private bool F_ValidaValores(double valor)
        {
            double dValor = 0;
            return double.TryParse(valor.ToString(), out dValor);
        }

    }
}
