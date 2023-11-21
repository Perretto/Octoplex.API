using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Kernel;
using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Domain.Produtos.DTO;
using Octoplex.Produtos.Infra.Data.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octoplex.Produtos.Infra.Data.Produtos
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly ProdutoDbContext _context;
        private readonly DBSession _db;
        public ProdutosRepository(ProdutoDbContext produtoDbContext, DBSession dbsession)
        {
            _context = produtoDbContext;
            _db = dbsession;
        }
        public async Task<Result<Exception, Produto>> Adicionar(Produto produto)
        {
            _context.Add(produto);
            var produtoNovo = await _context.SaveChangesAsync();
            var produtoAdicionado = Result<Exception, Produto>.Of(produto);
            if (produtoAdicionado.IsFailure)
            {
                return produtoAdicionado.Failure;
            }
            return produto;
        }

        public async Task<Result<Exception, Produto>> Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            var produtoAtualizado = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Produto>.Of(produto);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return produto;
        }

        public async Task<Result<Exception, Produto>> Excluir(int Id)
        {
            Produto produto = await _context.Produtos
                .Include(p => p.Impostos)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == Id);

            _context.Produtos.Remove(produto);
            var produtoExcluido = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Produto>.Of(produto);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return produto;
        }

        //public async Result<Exception, IQueryable<Produto>> Listar()
        public Result<Exception, IQueryable<Produto>> Listar()
        {
            var listaProduto = _context.Produtos
                .Include(p => p.Impostos)
                .Where(p => p.Status != "E")
                .AsNoTracking();
            if (!listaProduto.Any())
            {
                return new Result<Exception, IQueryable<Produto>>().Failure;
            }
            return Result<Exception, IQueryable<Produto>>.Of(listaProduto);
        }

        /// <summary>
        /// Utilizando o DAPPER para efetuar a consulta 
        /// Para diminuir o risco com problema de performance no futuro
        /// Pois esta lista dependendo da quantidade de produtos e impostos poderá ser grande
        /// </summary>
        /// <returns>Retorna uma lista de produtos com Impostos</returns>
        public async Task<List<Produto>> ListarAsync()
        {
            //Dapper
            using (var conn = _db.Connection)
            {
                string query = @"Select P.Id, codigo, descricao, valorCompra , valorvenda,
                                un, validade, estoque, lucro, dtUltvenda, valultvenda, codGru,
                                estMin, idFornecedor1, idFornecedor1, status, P.idEmpresa, valorA, valorB, 
                                iniPromo, fimPromo, balanca, TeclaBalanca, CodigoNoFornecedor, ImprimeCozinha,
                                guidIntegracao, tipo, divForn, P.DataAlteracao, CodigoAnp, * from Produtos P
                                LEFT JOIN IMPOSTOS I ON I.IDPRODUTO = P.ID";
                                //JOIN CLIENTES C ON C.LANCA = P.IDFORNECEDOR1";


                #region JOIN/MAP
                var produtos = await conn.QueryAsync<Produto, Imposto, Produto>(
                    sql: query,
                    map: (product, tax) =>
                    {
                        product.Imposto = tax;
                        return product;
                    },
                    //param: new { Id = 1 },
                    splitOn: "Id",
                    transaction: _db.Transaction);
                #endregion

                return produtos.ToList();

                #region Consulta Simples Dapper
                //Para efetuar uma consulta simples sem o JOIN, criar uma query simples
                //Conforme a query acima, porém sem o JOIN, neste caso utilizar conforme abaixo

                //List<Produto> produtos = (await conn.QueryAsync<Produto>(sql: query)).ToList();
                //return Result<Exception, IQueryable<Produto>>.Of((IQueryable<Produto>)produtos);
                #endregion
            }
        }

        public Result<Exception, IQueryable<Produto>> ListarPorCfop(int Cfop)
        {
            IQueryable<Produto> listProdutosPorCfop =
                (from imposto in _context.Impostos
                 join prod in _context.Produtos on imposto.IdProduto equals prod.Id
                 where imposto.Cfop == Cfop.ToString()
                 select new Produto
                 {
                     Id = prod.Id,
                     Codigo = prod.Codigo,
                     Descricao = prod.Descricao,
                     Vrcompra = prod.Vrcompra,
                     Vrvista = prod.Vrvista,
                     Un = prod.Un,
                     Validade = prod.Validade,
                     Estq = prod.Estq,
                     Lucro = prod.Lucro,
                     DtUltvenda = prod.DtUltvenda,
                     Valultvenda = prod.Valultvenda,
                     CodGru = prod.CodGru,
                     EstMin = prod.EstMin,
                     Forn1 = prod.Forn1,
                     Forn2 = prod.Forn2,
                     Status = prod.Status,
                     IdEmp = prod.IdEmp,
                     ValorA = prod.ValorA,
                     ValorB = prod.ValorB,
                     IniPromo = prod.IniPromo,
                     FimPromo = prod.FimPromo,
                     Balanca = prod.Balanca,
                     TeclaB = prod.TeclaB,
                     CodPf = prod.CodPf,
                     ImpCoz = prod.ImpCoz,
                     Guid = prod.Guid,
                     Tipo = prod.Tipo,
                     DivForn = prod.DivForn,
                     DtAlt = prod.DtAlt,
                     Codigoanp = prod.Codigoanp,

                     Imposto = (from I in _context.Impostos
                                 where I.IdProduto == prod.Id
                                 select new Imposto
                                 {
                                     IdProduto = prod.Id,
                                     Cest = imposto.Cest,
                                     Cfop = imposto.Cfop,
                                     Ncm = imposto.Ncm,
                                     Origem = imposto.Origem,
                                     CstIcms = imposto.CstIcms,
                                     AliqIcms = imposto.AliqIcms,
                                     Csosn = imposto.Csosn,
                                     CstIpi = imposto.CstIpi,
                                     AliqIpi = imposto.AliqIpi,
                                     CstPis = imposto.CstPis,
                                     AliqPis = imposto.AliqPis,
                                     CstCofins = imposto.CstCofins,
                                     AliqCofins = imposto.AliqCofins,
                                     CodigoSefaz = imposto.CodigoSefaz,
                                     IbptAliq = imposto.IbptAliq,
                                     CodigoUf = imposto.CodigoUf,
                                 }).FirstOrDefault()
                 }).AsNoTracking().AsQueryable();
            
            #region Lista Produtos CFOP
            //Comentado 160123
            //Impostos = (from imp in _context.Impostos where imp.Cfop == Cfop.ToString()
            //            && imp.IdProduto == prod.Id
            //            select new {Imposto = imposto }.Imposto
            //            ).ToList(),
            #endregion

            var productGetCfop = Result<Exception, IQueryable<Produto>>.Of(listProdutosPorCfop.AsQueryable());
            if (productGetCfop.IsFailure)
            {
                return productGetCfop.Failure;
            }
            return productGetCfop;
        }

        public Result<Exception, IQueryable<Produto>> ListarPorNcm(string Ncm)
        {
            IQueryable<Produto> listProdutosPorNcm =
                (from imposto in _context.Impostos
                 join prod in _context.Produtos on imposto.IdProduto equals prod.Id
                 where imposto.Ncm == Ncm
                 select new Produto
                 {
                     Id = prod.Id,
                     Codigo = prod.Codigo,
                     Descricao = prod.Descricao,
                     Vrcompra = prod.Vrcompra,
                     Vrvista = prod.Vrvista,
                     Un = prod.Un,
                     Validade = prod.Validade,
                     Estq = prod.Estq,
                     Lucro = prod.Lucro,
                     DtUltvenda = prod.DtUltvenda,
                     Valultvenda = prod.Valultvenda,
                     CodGru = prod.CodGru,
                     EstMin = prod.EstMin,
                     Forn1 = prod.Forn1,
                     Forn2 = prod.Forn2,
                     Status = prod.Status,
                     IdEmp = prod.IdEmp,
                     ValorA = prod.ValorA,
                     ValorB = prod.ValorB,
                     IniPromo = prod.IniPromo,
                     FimPromo = prod.FimPromo,
                     Balanca = prod.Balanca,
                     TeclaB = prod.TeclaB,
                     CodPf = prod.CodPf,
                     ImpCoz = prod.ImpCoz,
                     Guid = prod.Guid,
                     Tipo = prod.Tipo,
                     DivForn = prod.DivForn,
                     DtAlt = prod.DtAlt,
                     Codigoanp = prod.Codigoanp,

                     Imposto = (from I in _context.Impostos
                                 where I.IdProduto == prod.Id
                                 select new Imposto
                                 {
                                     IdProduto = prod.Id,
                                     Cest = imposto.Cest,
                                     Cfop = imposto.Cfop,
                                     Ncm = imposto.Ncm,
                                     Origem = imposto.Origem,
                                     CstIcms = imposto.CstIcms,
                                     AliqIcms = imposto.AliqIcms,
                                     Csosn = imposto.Csosn,
                                     CstIpi = imposto.CstIpi,
                                     AliqIpi = imposto.AliqIpi,
                                     CstPis = imposto.CstPis,
                                     AliqPis = imposto.AliqPis,
                                     CstCofins = imposto.CstCofins,
                                     AliqCofins = imposto.AliqCofins,
                                     CodigoSefaz = imposto.CodigoSefaz,
                                     IbptAliq = imposto.IbptAliq,
                                     CodigoUf = imposto.CodigoUf,
                                 }).FirstOrDefault()
                 }).AsNoTracking().AsQueryable();

            #region Lista Produtos NCM
            //Comentado 160123
            //Impostos = (from imp in _context.Impostos where imp.Ncm == Ncm
            //            && imp.IdProduto == prod.Id
            //            select new {Imposto = imposto}.Imposto
            //            ).ToList()

            //select new {Produto = prod}.Produto;
            #endregion

            var productGet = Result<Exception, IQueryable<Produto>>.Of(listProdutosPorNcm.AsQueryable());
            if (productGet.IsFailure)
            {
                return productGet.Failure;
            }
            return productGet;
        }

        public async Task<List<Produto>> ListarProdutosAtivosAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = @"Select P.Id,  
                                * from vwProdutosAtivos P
                                LEFT JOIN IMPOSTOS I ON I.IDPRODUTO = P.ID";

                #region JOIN/MAP
                var produtos = await conn.QueryAsync<Produto, Imposto, Produto>(
                    sql: query,
                    map: (product, tax) =>
                    {
                        product.Imposto = tax;
                        return product;
                    },
                    //param: new { Id = 1 },
                    splitOn: "Id",
                    transaction: _db.Transaction);
                #endregion

                return produtos.ToList();

                #region Consulta Simples Dapper
                //Para efetuar uma consulta simples sem o JOIN, criar uma query simples
                //Conforme a query acima, porém sem o JOIN, neste caso utilizar conforme abaixo

                //List<Produto> produtos = (await conn.QueryAsync<Produto>(sql: query)).ToList();
                //return Result<Exception, IQueryable<Produto>>.Of((IQueryable<Produto>)produtos);
                #endregion
            }
        }

        public Result<Exception, IQueryable<ProdutosDTO>> ListaSimplesProduto()
        {
            var listaProduto = _context.Produtos
               .Include(p => p.Impostos)
               .AsNoTracking()
               .AsQueryable();

            if (!listaProduto.Any())
            {
                return new Result<Exception, IQueryable<ProdutosDTO>>().Failure;
            }
            return Result<Exception, IQueryable<ProdutosDTO>>.Of((IQueryable<ProdutosDTO>)listaProduto);
        }

        public async Task<Result<Exception, Produto>> ObterPorIdAsync(int Id)
        {
            var produtoId = await _context.Produtos
                .Include(p => p.Impostos)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == Id);
            var produtoGet = Result<Exception, Produto>.Of(produtoId);
            if (produtoGet.IsFailure)
            {
                return produtoGet.Failure;
            }
            return produtoId;
        }


    }
}
