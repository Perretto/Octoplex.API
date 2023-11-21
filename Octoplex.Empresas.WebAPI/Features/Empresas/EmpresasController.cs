using Octoplex.Empresas.Domain.Empresas;
using Octoplex.Empresas.WebAPI.Features.Empresas.ViewModels;
using Octoplex.Kernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Octoplex.Empresas.WebAPI.Features.Empresas
{
    /// <summary>
    /// Controlador de Empresas
    /// Responsável por prover os dados relacionado a entidade empresa
    /// </summary>
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        /// <summary>
        /// EndPoint responsável por listar todas empresas
        /// </summary>
        /// <returns>Lista de Empresas</returns>
        [ProducesResponseType(typeof(ListEmpresasViewModel), StatusCodes.Status200OK)]
        [Route("listar")]
        [HttpGet]
        public async Task<IActionResult> ListarEmpresa()
        {
            var listaEmpresa = await Task.FromResult(_empresaRepository.Listar());
            if(listaEmpresa.IsFailure)
            {
                return BadRequest();
            }
            return Ok(listaEmpresa.Success);
        }

        /// <summary>
        /// EndPoint responsável por obter uma empresa pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Empresa</returns>
        [ProducesResponseType(typeof(EmpresaViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEmpresaByIdAsync(Guid id)
        {
            var empresa = await _empresaRepository.ObterPorIdAsync(id);
            if (empresa.IsFailure)
            {
                return BadRequest();
            }
            return Ok(empresa.Success);
        }

        /// <summary>
        /// EndPoint responsável por atualizar uma empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns>Empresa</returns>
        [ProducesResponseType(typeof(EmpresaViewModel), StatusCodes.Status200OK)]
        [Route("Atualizar")]
        [HttpPut]
        public async Task<IActionResult> AtualizarEmpresa(Empresa empresa)
        {
            var empresaAtualizado = await _empresaRepository.Atualizar(empresa);
            if (empresaAtualizado.IsFailure)
            {
                return BadRequest();
            }
            return Ok(empresaAtualizado.Success);
        }

        /// <summary>
        /// EndPoint responsável por excluir uma empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(EmpresaViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirEmpresa(Empresa empresa)
        {
            var empresaExcluida = await _empresaRepository.Excluir(empresa);
            if (empresaExcluida.IsFailure)
            {
                return BadRequest();
            }
            return Ok(empresaExcluida.Success);
        }

        /// <summary>
        /// EndPoint responsável por adicionar uma empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns>Empresa</returns>
        [ProducesResponseType(typeof(EmpresaViewModel), StatusCodes.Status200OK)]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AdicionarEmpresa(Empresa empresa)
        {
            var empresaAdicionada = await _empresaRepository.Adicionar(empresa);
            if (empresaAdicionada.IsFailure)
            {
                return BadRequest();
            }
            return Ok(empresaAdicionada.Success);
        }
    }
}
