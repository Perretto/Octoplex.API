using Octoplex.Kernel;
using Octoplex.Produtos.Domain.Produtos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Domain.Produtos
{
    public interface IProdutosRepository
    {
        Task<Result<Exception, Produto>> Adicionar(Produto produto);
        Task<Result<Exception, Produto>> Atualizar(Produto produto);
        Task<Result<Exception, Produto>> Excluir(int Id);
        Task<List<Produto>> ListarAsync();
        Task<List<Produto>> ListarProdutosAtivosAsync();
        Result<Exception, IQueryable<Produto>> Listar();
        Result<Exception, IQueryable<ProdutosDTO>> ListaSimplesProduto();
        Task<Result<Exception, Produto>> ObterPorIdAsync(int Id);
        Result<Exception, IQueryable<Produto>> ListarPorNcm(string Ncm);
        Result<Exception, IQueryable<Produto>> ListarPorCfop(int Cfop);
    }
}
