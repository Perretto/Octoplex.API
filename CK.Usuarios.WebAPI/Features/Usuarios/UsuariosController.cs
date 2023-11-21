using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Infra.Data.Usuarios;
using Octoplex.Usuarios.WebAPI.Features.Usuarios.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.OData.Query;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Queries;
using System.Threading;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Commands;

namespace Octoplex.Usuarios.WebAPI.Features.Usuarios
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMediator mediator, IConfiguration configuration, ILogger<UsuariosController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// EndPoint responsável por listar todos usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        [ProducesResponseType(typeof(ListUsuariosViewModel), StatusCodes.Status200OK)]
        [Route("listar")]
        [HttpGet]
        //public async Task<IActionResult> ListarUsuario(ODataQueryOptions<ListUsuariosViewModel> queryOptions)
        public async Task<IActionResult> ListarUsuario()
        {
            try
            {
                var getUsuarios = new UsuarioListarQuery();               
                var result = await Task.FromResult(_mediator.Send(getUsuarios));
                if (result.Result == null)
                {
                    _logger.LogInformation("Nenhum usuário encontrado!");
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                _logger.LogError("400 - BadRequest");
                return BadRequest();
            }
            #region Utilizando a controller sem Handle
            //var  result = await Task.FromResult(_usuarioRepository.Listar());
            //var listaUsuario = await Task.FromResult(_usuarioRepository.Listar());
            //if (listaUsuario.IsFailure)
            //{
            //    return BadRequest();
            //}
            //return Ok(listaUsuario.Success);
            #endregion
        }

        /// <summary>
        /// EndPoint responsável por obter um usuario pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUsuarioByIdAsync(int id)
        {
            try
            {
                var getUsuarios = new UsuarioListarPorIdQuery
                {
                    Id = id
                };
                var result = await Task.FromResult(_mediator.Send(getUsuarios));
                if (result.Result == null)
                {
                    _logger.LogInformation("Usuário não encontrado com o id: " + id);
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                _logger.LogError("400 - BadRequest");
                return BadRequest();
            }
            #region Metodo Antigo
            //var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            //if (usuario.IsFailure)
            //{
            //    return BadRequest();
            //}
            //return Ok(usuario.Success);
            #endregion
        }

        /// <summary>
        /// EndPoint responsável por atualizar uma empresa
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Usuarrio</returns>
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        [Route("Atualizar")]
        [HttpPut]
        public async Task<IActionResult> AtualizarUsuario(Usuario usuario)
        {
            var userAtualizado = new UsuarioCommand(usuario);
            var result = await Task.FromResult(_mediator.Send(userAtualizado));
            if(result.IsFaulted)
            {
                _logger.LogError("400 - BadRequest");
                return BadRequest();
            }
            return Ok(result.Result);

            #region Metodo Antigo
            //var usuarioAtualizado = await _usuarioRepository.Atualizar(usuario);
            //if (usuarioAtualizado.IsFailure)
            //{
            //    return BadRequest();
            //}
            //return Ok(usuarioAtualizado.Success);
            #endregion
        }

        /// <summary>
        /// EndPoint responsável por excluir um usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirUsuario(Usuario usuario)
        {
            var usuarioExcluir = new UsuarioCommand(usuario);
            var result = await Task.FromResult(_mediator.Send(usuarioExcluir));
            if (result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);

            #region Metodo Antigo
            //var usuarioExcluido = await _usuarioRepository.Excluir(usuario);
            //if (usuarioExcluido.IsFailure)
            //{
            //    return BadRequest();
            //}
            //return Ok(usuarioExcluido.Success);
            #endregion
        }

        /// <summary>
        /// EndPoint responsável por adicionar um usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Usuario</returns>
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(Usuario usuario)
        {
            var usuarioAdicionado = new UsuarioCommand(usuario);
            var result = await Task.FromResult(_mediator.Send(usuarioAdicionado));
            if(result.IsFaulted)
            {
                return BadRequest();
            }
            return Ok(result.Result);

            #region Método Antigo
            //var usuarioAdicionado = await _usuarioRepository.Adicionar(usuario);
            //if (usuarioAdicionado.IsFailure)
            //{
            //    return BadRequest();
            //}
            //return Ok(usuarioAdicionado.Success);
            #endregion
        }

        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario user)
        {
            var users = await _usuarioRepository.GetUser(user.Username, user.Password);

            if (users.IsFailure)
            {
                _logger.LogInformation("Falha ao localizar usuário!");
                return BadRequest();
            }

            if (users.Success == null)
                return NotFound(new { message = "Usuário ou senha inválido(s)" });

            var token = TokenService.GenerateToken(user);
            var S = TokenService.ValidateToken(token);
            users.Success.Token = token;
            users.Success.ExpiredToken = 10000;
            user.Token = token;

            return Ok(users.Success);

            //return new
            //{
            //    user = user,
            //    token = token
            //};
        }

        public static class TokenService
        {
            public static string GenerateToken(Usuario user)
            {
                ///Teste
                var builder = WebApplication.CreateBuilder();
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("SettingsSecret").GetSection("Secret").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                
                return tokenHandler.WriteToken(token);
            }

            public static string ValidateToken(string Token)
            {
                var builder = WebApplication.CreateBuilder();
                var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("SettingsSecret").GetSection("Secret").Value);
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var claims = handler.ValidateToken(Token, validations, out var tokenSecure);

                return claims.Identity.Name;
            }
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}
