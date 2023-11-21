using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Impostos.Web.Application.Features.Impostos.Commands;
using Octoplex.Impostos.WebAPI.Features.Impostos.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Octoplex.Impostos.WebAPI.Features.Impostos
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    public class ImpostosController : ControllerBase
    {
        private readonly IImpostosRepository _impostosRepository;
        private readonly IMediator _mediator;
        public ImpostosController(IImpostosRepository impostosRepository, IMediator mediator)
        {
            _impostosRepository = impostosRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// EndPoint responsável por listar todos clientes
        /// </summary>
        /// <returns>Lista de Impostos</returns>
        [ProducesResponseType(typeof(ListImpostosViewModel), StatusCodes.Status200OK)]
        [Route("listar")]
        [HttpGet]
        public async Task<IActionResult> ListarImpostos()
        {
            var listaImpostos = await Task.FromResult(_impostosRepository.Listar());
            if (listaImpostos.IsFailure)
            {
                return BadRequest();
            }
            return Ok(listaImpostos.Success);
        }

        /// <summary>
        /// EndPoint Responsável por obter um imposto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ImpostoViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetImpostoByIdAsync(int id)
        {
            var imposto = await _impostosRepository.ObterPorIdAsync(id);
            if (imposto.IsFailure)
            {
                return BadRequest();
            }
            return Ok(imposto.Success);
        }

        /// <summary>
        /// EndPoint Responsável por obter um imposto pelo ID do Produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ImpostoViewModel), StatusCodes.Status200OK)]
        [Route("Produto/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetImpostoByIdAProdutosync(int id)
        {
            var imposto = await _impostosRepository.ObterPorIdProdutoAsync(id);
            if (imposto.IsFailure)
            {
                return BadRequest();
            }
            return Ok(imposto.Success);
        }
        /// <summary>
        /// EndPoint responsável por atualizar um imposto
        /// </summary>
        /// <param name="imposto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ImpostoViewModel), StatusCodes.Status200OK)]
        [Route("Atualizar")]
        [HttpPut]
        public async Task<IActionResult> AtualizarImposto(Imposto imposto)
        {
            var impostoAtualizado = await _impostosRepository.Atualizar(imposto);
            if (impostoAtualizado.IsFailure)
            {
                return BadRequest();
            }
            return Ok(impostoAtualizado.Success);
        }

        /// <summary>
        /// EndPoint responsável por excluir um imposto
        /// </summary>
        /// <param name="imposto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ImpostoViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirImposto(Imposto imposto)
        {
            var impostoExcluido = await _impostosRepository.Excluir(imposto);
            if (impostoExcluido.IsFailure)
            {
                return BadRequest();
            }
            return Ok(impostoExcluido.Success);
        }

        /// <summary>
        /// EndPoint responsável por inserir um Imposto
        /// </summary>
        /// <param name="imposto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ImpostoViewModel), StatusCodes.Status200OK)]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AdicionarImposto(Imposto imposto)
        {
            var impostoAdicionado = await _impostosRepository.Adicionar(imposto);
            if (impostoAdicionado.IsFailure)
            {
                return BadRequest();
            }
            return Ok(impostoAdicionado.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// /// <param name="imposto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ImpostoViewModel), StatusCodes.Status200OK)]
        [Route("calc")]
        [HttpGet]
        public async Task<IActionResult> CalcularImpostoProduto(ImpostoCalculo imposto)
        {
            var calculoImposto = new ImpostoCalcularCommand(imposto);
            var result = await Task.FromResult(_mediator.Send(calculoImposto));
            if (result.IsFaulted)
            {
               return BadRequest();
            }
            return Ok(result.Result);
        }

    }
}
