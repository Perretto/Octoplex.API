using Octoplex.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Domain.Impostos
{
    public interface IImpostosRepository
    {
        Task<Result<Exception, Imposto>> Adicionar(Imposto imposto);
        Task<Result<Exception, Imposto>> Atualizar(Imposto imposto);
        Task<Result<Exception, Imposto>> Excluir(Imposto imposto);
        Result<Exception, IQueryable<Imposto>> Listar();
        Task<Result<Exception, Imposto>> ObterPorIdAsync(int Id);
        Task<Result<Exception, IQueryable<Imposto>>> ObterPorIdProdutoAsync(int Id);
        Task<ImpostoCalculo> CalcularImposto(ImpostoCalculo impostoCalculo);
    }
}
