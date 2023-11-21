using AutoMapper;
using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Commands;
using Octoplex.Produtos.Web.Application.Features.Produtos.Queries;
using Octoplex.Produtos.Domain.Produtos.DTO;
using Octoplex.Produtos.WebAPI.Features.Produtos.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace Octoplex.Produtos.WebAPI.Features.Produtos
{
    /// <summary>
    /// Controlador de Produtos
    /// Responsável por prover os dados relacionado a produtos
    /// </summary>
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]

    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepository _produtosRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private IValidator<Produto> _validator;

        public ProdutosController(IValidator<Produto> validator, IProdutosRepository produtosRepository, IMediator mediator, IMapper mapper, ILogger<ProdutosController> logger)
        {
            _produtosRepository = produtosRepository;
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }
        //Mapper utilizado para mapear objetos diferentes

        /// <summary>
        /// EndPoint Responsável por listar todos os produtos
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        [ProducesResponseType(typeof(ListProdutosViewModel), StatusCodes.Status200OK)]
        [Route("listar")]
        [HttpGet]
        //[Authorize("MANAGER")]
        public async Task<IActionResult> ListarProdutos()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var getProdutos = new ProdutoListarQuery();
                var result = await Task.FromResult(_mediator.Send(getProdutos));
                if (result.Result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// EndPoint Responsável por listar assincrono todos os produtos
        /// Utilizando DAPPER para diminuir o risco com problema de performance no futuro
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        [ProducesResponseType(typeof(ListProdutosViewModel), StatusCodes.Status200OK)]
        [Route("listarasync")]
        [HttpGet]
        public async Task<IActionResult> ListarProdutosAsync()
        {
            try
            {
                
                var result = await Task.FromResult(_produtosRepository.ListarAsync());
                if (result.IsFaulted)
                {
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// EndPoint Responsável por listar produtos ativos assincrono
        /// Utilizando DAPPER e VIEW(SQL) para diminuir o risco com problema de performance no futuro
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        [ProducesResponseType(typeof(ListProdutosViewModel), StatusCodes.Status200OK)]
        [Route("activelist")]
        [HttpGet]
        public async Task<IActionResult> ListarProdutosAtivosAsync()
        {
            try
            {
                var result = await Task.FromResult(_produtosRepository.ListarProdutosAtivosAsync());
                if (result.IsFaulted)
                {
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// EndPoint Responsável por retornar uma lista simples de todos os produtos
        /// </summary>
        /// <returns>Lista Simples de Produtos</returns>
        [ProducesResponseType(typeof(ListaSimplesProdutoViewModel), StatusCodes.Status200OK)]
        [Route("listarsimples")]
        [HttpGet]
        public async Task<IActionResult> ListaSimplesProdutos()
        {
            try
            {
                var getListProdutos = new ProdutoListarQuery();
                var listaProd = await Task.FromResult(_mediator.Send(getListProdutos));
                var prodDTO =  _mapper.Map<List<ProdutosDTO>>(listaProd.Result);
                _logger.LogInformation("SUCCESS ===== " + DateTime.Now + "===== Lista simples de produto carregada com sucesso");
                return Ok(prodDTO);
            }
            catch
            {
                _logger.LogError("ERROR ===== " + DateTime.Now + "===== Erro ao carregar lista simples produtos");
                return BadRequest();
            }
        }

        /// <summary>
        /// EndPoint responsável por obter um produto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Produto</returns>
        [ProducesResponseType(typeof(ProdutosViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProdutoByIdAsync(int id)
        {
            try
            {
                var getProdutosId = new ProdutoListarPorIdQuery
                {
                    Id = id
                };
                var result = await Task.FromResult(_mediator.Send(getProdutosId));
                if (result.Result == null)
                {
                    _logger.LogInformation("ATENCAO Produto não encontrado com o id: " + id);
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Lista os produtos por um determinado CFOP
        /// </summary>
        /// <param name="Cfop"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ProdutosViewModel), StatusCodes.Status200OK)]
        [Route("cfop")]
        [HttpGet]
        public async Task<IActionResult> ListarProdutosPorCfop(int Cfop)
        {
            var getProdutosCfop = new ProdutoListarPorCfopQuery 
            { 
                Cfop = Cfop 
            };
            var result = await Task.FromResult(_mediator.Send(getProdutosCfop));
            if(result.Result == null)
            {
                _logger.LogInformation("ATENCAO Não foi possivel obter a lista de produtos com CFOP: " + Cfop);
                return NotFound();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// Lista os produtos por um determinado NCM
        /// </summary>
        /// <param name="Ncm"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ProdutosViewModel), StatusCodes.Status200OK)]
        [Route("ncm")]
        [HttpGet]
        public async Task<IActionResult> ListarProdutosPorNcm(string Ncm)
        {
            var getProdutosNcm = new ProdutoListarPorNcmQuery
            {
                NCM = Ncm
            };
            var result = await Task.FromResult(_mediator.Send(getProdutosNcm));
            if(result.Result == null) 
            {
                _logger.LogInformation("ATENCAO Não foi possivel obter a lista de produtos com NCM: " + Ncm);
                return NotFound();
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint responsável por atualizar um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>Produto</returns>
        [ProducesResponseType(typeof(ProdutosViewModel), StatusCodes.Status200OK)]
        [Route("update")]
        [HttpPut]
        //[Authorize("MANAGER")]
        public async Task<IActionResult> AtualizarProduto([FromBody] Produto produto)
        {
            ValidationResult results = await _validator.ValidateAsync(produto);
            if (!results.IsValid)
            {
                //Abaixo Copia os resultados da validação para ModelState.
                //ASP.NET usa a coleção ModelState para preencher
                // mensagens de erro na View.
                results.AddToModelState(this.ModelState);

                //Adicionando o LOG da validação
                _logger.LogInformation("ERROR ===== " + DateTime.Now + " ===== Erro ao atualizar o produto: " + produto.Descricao + " =>" + results.Errors);
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ERROR ===== " + DateTime.Now + " ===== Erro ao atualizar o produto: " + produto.Descricao + " =>" + results.Errors);
                
                //renderiza novamente a visualização quando a validação falhou
                //return View("Create", produto);
                //return BadRequest(results.Errors);
                return BadRequest(results.ToString());
            }
            var produtoAtualizado = new ProdutoAtualizadoCommand(produto);
            var result = await Task.FromResult(_mediator.Send(produtoAtualizado));
            if (result.IsFaulted)
            {
                _logger.LogError("ERROR ===== " + DateTime.Now + "===== Erro ao atualizar o produto: " + result.Result.Descricao + "/n" +
                    result.Exception);
                Console.WriteLine("ERROR ===== " + DateTime.Now + "===== Erro ao atualizar o produto: " + result.Result.Descricao + "/n" +
                    result.Exception);

                Console.ResetColor();
                return BadRequest();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            _logger.LogInformation("SUCCESS *** " + DateTime.Now + " *** Produto atualizado com sucesso: " + produto.Descricao);
            
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint responsável por excluir um produto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Produto</returns>
        [ProducesResponseType(typeof(ProdutosViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirProduto(int Id)
        {
            //var produtoExcluido = new ExcluirProdutoCommand(produto);

            var produtoExcluido = new ExcluirProdutoCommand(Id);
            //{
            //    Id = Id
            //};

            var result = await Task.FromResult(_mediator.Send(produtoExcluido));
            if (result.IsFaulted)
            {
                _logger.LogError("ERROR ===== " + DateTime.Now + "===== Erro ao excluir o produto: " + result.Result.Descricao + "/n" +
                   result.Exception);
                return BadRequest();
            }
            _logger.LogInformation("SUCCESS *** " + DateTime.Now + " *** Produto excluido com sucesso: " + result.Result.Descricao);
            return Ok(result.Result);
        }

        /// <summary>
        /// EndPoint responsável por adicionar um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>Produto</returns>
        [ProducesResponseType(typeof(ProdutosViewModel), StatusCodes.Status200OK)]
        [Route("insert")]
        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] Produto produto)
        {
            ValidationResult results = await _validator.ValidateAsync(produto);
            if (!results.IsValid)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                results.AddToModelState(this.ModelState);

                // re-render the view when validation failed.
                //return View("Create", person);
                return BadRequest(results.Errors);
            }
            var produtoAdicionado = new ProdutoCommand(produto);
            var result = await Task.FromResult(_mediator.Send(produtoAdicionado));
            if (string.IsNullOrWhiteSpace(result.Result.Codigo) || result.IsFaulted)
            {
                _logger.LogError("ERROR ===== " + DateTime.Now + "===== Erro ao adicioar o produto: " + result.Result.Descricao + "/n" +
                   result.Exception);

                return BadRequest();
            }
            _logger.LogInformation("SUCCESS *** " + DateTime.Now + " *** Produto cadastrado com sucesso: " + produto.Descricao);
            return Ok(result.Result);
        }
    }
}
