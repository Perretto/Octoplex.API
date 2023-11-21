using Octoplex.Kernel;
using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Infra.Data.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Exception, Usuario>> Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            var usuarioAdicionado = await _context.SaveChangesAsync();
            var usuarioSalvo = Result<Exception, Usuario>.Of(usuario);
            if (usuarioSalvo.IsFailure)
            {
                return usuarioSalvo.Failure;
            }
            return usuario;
        }

        public async Task<Result<Exception, Usuario>> Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            var usuarioAtualizado = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Usuario>.Of(usuario);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return usuario;
        }

        public async Task<Result<Exception, Usuario>> Excluir(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            var usuarioExcluido = await _context.SaveChangesAsync();
            var resultValidation = Result<Exception, Usuario>.Of(usuario);
            if (resultValidation.IsFailure)
            {
                return resultValidation.Failure;
            }
            return usuario;
        }

        public Result<Exception, IQueryable<Usuario>> Listar()
        {
            var listaUsuarios = _context.Usuarios;
            if (!listaUsuarios.Any())
            {
                return new Result<Exception, IQueryable<Usuario>>().Failure;
            }
            return Result<Exception, IQueryable<Usuario>>.Of(listaUsuarios);
        }

        public async Task<Result<Exception, Usuario>> ObterPorIdAsync(int Id)
        {
            //id
            var usuarioId =  await Task.FromResult(_context.Usuarios
             .AsNoTracking()
             .FirstOrDefault(u => u.Id == Id));
            var usuarioGet = Result<Exception, Usuario>.Of(usuarioId);
            if (usuarioGet.IsFailure)
            {
                return usuarioGet.Failure;
            }
            return usuarioId;
        }

        public async Task<Result<Exception, Usuario>> GetUser(string UserName, string Password)
        {
            try
            {
                var usuario = await Task.FromResult(_context.Usuarios
                .AsNoTracking()
                .FirstOrDefault(u => u.Username == UserName && u.Password == Password));
                usuario.Id = 0;
                usuario.Password = "";
                var usuarioGet = Result<Exception, Usuario>.Of(usuario);
                if (usuarioGet.IsFailure)
                {
                    return usuarioGet.Failure;
                }
                return usuarioGet;
                //return usuarioGet;
            }
            catch (Exception ex)
            {
                return new Exception();
            }
            
        }
    }
}
