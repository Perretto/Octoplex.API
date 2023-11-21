using Octoplex.Clientes.Domain.Clientes;
using Octoplex.Clientes.Infra.Data.Contexts;
using Octoplex.Kernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Clientes.Infra.Data.Clientes
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly ClienteDbContext _context;
        public ClientesRepository(ClienteDbContext clienteDbContext)
        {
            _context = clienteDbContext;
        }
        public async Task<Result<Exception, Cliente>> Adicionar(Cliente cliente)
        {
            _context.Add(cliente);
            var clienteNovo = await _context.SaveChangesAsync();
            var clienteAdicionado = Result<Exception, Cliente>.Of(cliente);
            if (clienteAdicionado.IsFailure)
            {
                return clienteAdicionado.Failure;
            }
            return cliente;
        }

        public async Task<Result<Exception, Cliente>> Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            var clienteAtualizado = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Cliente>.Of(cliente);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return cliente;
        }

        public async Task<Result<Exception, Cliente>> Excluir(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            var clienteExcluido = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Cliente>.Of(cliente);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return cliente;
        }

        public Result<Exception, IQueryable<Cliente>> ListaClientesPorCep(string Cep)
        {
            IQueryable<Cliente> listClients = _context.Clientes.Where(c => c.Cep == Cep).AsQueryable();
            var clientGet = Result<Exception, IQueryable<Cliente>>.Of(listClients);
            if(clientGet.IsFailure)
            {
                return clientGet.Failure;
            }
            
            return clientGet;
        }

        public Result<Exception, IQueryable<Cliente>> Listar()
        {
            return _context.Clientes;
        }

        public async Task<Result<Exception, Cliente>> ObterPorCPFCNPJ(string CpfCnpj)
        {
            var clientResult = await _context.Clientes
                //.Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.CnpjCpf == CpfCnpj);
            var clienteGet = Result<Exception, Cliente>.Of(clientResult);
            if (clienteGet.IsFailure)
            {
                return clienteGet.Failure;
            }
            return clientResult;
        }

        public async Task<Result<Exception, Cliente>> ObterPorIdAsync(Guid Id)
        {
            var clientePorId = await _context.Clientes
                //.Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.Id == Id);

            var clienteGet = Result<Exception, Cliente>.Of(clientePorId);

            if (clienteGet.IsFailure)
            {
                return clienteGet.Failure;
            }
            return clientePorId;
        }
    }
}
