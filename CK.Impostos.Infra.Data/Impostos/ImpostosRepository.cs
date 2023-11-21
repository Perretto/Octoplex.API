using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Impostos.Infra.Data.Contexts;
using Octoplex.Kernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Infra.Data.Impostos
{
    public class ImpostosRepository : IImpostosRepository
    {
        private readonly ImpostoDbContext _context;
        public ImpostosRepository(ImpostoDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Exception, Imposto>> Adicionar(Imposto imposto)
        {
            _context.Add(imposto);
            var impostoNovo = await _context.SaveChangesAsync();
            var impostoAdicionado = Result<Exception, Imposto>.Of(imposto);
            if (impostoAdicionado.IsFailure)
            {
                return impostoAdicionado.Failure;
            }
            return imposto;
        }

        public async Task<Result<Exception, Imposto>> Atualizar(Imposto imposto)
        {
            _context.Update(imposto);
            var impostoAtualizado = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Imposto>.Of(imposto);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return imposto;
        }

        public async Task<ImpostoCalculo> CalcularImposto(ImpostoCalculo impostoCalculo)
        {
            return await Task.FromResult(impostoCalculo.CalcularImpostoProduto());
        }

        public async Task<Result<Exception, Imposto>> Excluir(Imposto imposto)
        {
            _context.Remove(imposto);
            _ = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Imposto>.Of(imposto);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return imposto;
        }

        public Result<Exception, IQueryable<Imposto>> Listar()
        {
            var listaImposto = _context.Impostos
                .AsNoTracking();
            if (!listaImposto.Any())
            {
                return new Result<Exception, IQueryable<Imposto>>();
            }
            return Result<Exception, IQueryable<Imposto>>.Of(listaImposto);
            //return listaImposto;
        }

        public async Task<Result<Exception, Imposto>> ObterPorIdAsync(int Id)
        {
            var impostoId = await _context.Impostos.FirstOrDefaultAsync(i => i.IdImposto == Id);
            var impostoGet = Result<Exception, Imposto>.Of(impostoId);
            if (impostoGet.IsFailure)
            {
                return impostoGet.Failure;
            }
            return impostoId;
        }

        public async Task<Result<Exception, IQueryable<Imposto>>> ObterPorIdProdutoAsync(int Id)
        {
            var listProductImposto =  _context.Impostos
                .Where(i => i.IdProduto == Id)
                .AsNoTracking();
            var impostoGet = Result<Exception, IQueryable<Imposto>>.Of(listProductImposto);
            if (impostoGet.IsFailure)
            {
                return new Result<Exception, IQueryable<Imposto>>();
            }
            return Result<Exception, IQueryable<Imposto>>.Of(listProductImposto);
        }
    }
}
