using Octoplex.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Domain.Clientes
{
    public interface IClientesRepository
    {
        Task<Result<Exception, Cliente>> Adicionar(Cliente cliente);
        Task<Result<Exception, Cliente>> Atualizar(Cliente cliente);
        Task<Result<Exception, Cliente>> Excluir(Cliente cliente);
        Result<Exception, IQueryable<Cliente>> Listar();
        Task<Result<Exception, Cliente>> ObterPorIdAsync(Guid Id);
        Task<Result<Exception, Cliente>> ObterPorCPFCNPJ(string CpfCnpj);
        Result<Exception, IQueryable<Cliente>> ListaClientesPorCep(string Cep);

    }
}
