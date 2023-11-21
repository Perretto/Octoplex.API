using Octoplex.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octoplex.Empresas.Domain.Empresas
{
    public interface IEmpresaRepository
    {
        Task<Result<Exception, Empresa>> Adicionar(Empresa empresa);
        Task<Result<Exception, Empresa>> Atualizar(Empresa empresa);
        Task<Result<Exception, Empresa>> Excluir(Empresa empresa);
        Result<Exception, IQueryable<Empresa>> Listar();
        Task<Result<Exception, Empresa>> ObterPorIdAsync(Guid Id);
    }
}
