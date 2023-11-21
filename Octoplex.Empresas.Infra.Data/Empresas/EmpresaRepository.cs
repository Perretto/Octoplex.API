using Octoplex.Empresas.Domain.Empresas;
using Octoplex.Empresas.Infra.Data.Contexts;
using Octoplex.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Empresas.Infra.Data.Empresas
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly EmpresaDbContext _context;

        public EmpresaRepository(EmpresaDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Exception, Empresa>> Adicionar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            var empresaAdicionada = await _context.SaveChangesAsync();
            var empresaSalva = Result<Exception, Empresa>.Of(empresa);
            if (empresaSalva.IsFailure)
            {
                return empresaSalva.Failure;
            }
            return empresa;
        }

        public async Task<Result<Exception, Empresa>> Atualizar(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            var salvar = await _context.SaveChangesAsync();
            var salvarCallback = Result<Exception, Empresa>.Of(empresa);
            if (salvarCallback.IsFailure)
            {
                return salvarCallback.Failure;
            }

            return empresa;
        }

        public async Task<Result<Exception, Empresa>> Excluir(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            var result = await _context.SaveChangesAsync();
            var resultCallback = Result<Exception, Empresa>.Of(empresa);
            if (resultCallback.IsFailure)
            {
                return resultCallback.Failure;
            }
            return empresa;
        }

        public Result<Exception, IQueryable<Empresa>> Listar()
        {
            var listaEmpresas = _context.Empresas;
            return listaEmpresas;
        }

        public async Task<Result<Exception, Empresa>> ObterPorIdAsync(Guid Id)
        {
            var empresaId =await Task.FromResult( _context.Empresas
                .FirstOrDefault(e => e.Id == Id));
            var empresaGet = Result<Exception, Empresa>.Of(empresaId);
            if (empresaGet.IsFailure)
            {
                return empresaGet.Failure;
            }

            return empresaId;
        }
    }
}
