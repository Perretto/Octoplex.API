using Octoplex.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<Result<Exception, Usuario>> Adicionar(Usuario usuario);
        Task<Result<Exception, Usuario>> Atualizar(Usuario usuario);
        Task<Result<Exception, Usuario>> Excluir(Usuario usuario);
        Result<Exception, IQueryable<Usuario>> Listar();
        Task<Result<Exception, Usuario>> ObterPorIdAsync(int Id);
        Task<Result<Exception, Usuario>> GetUser(string UserName, string Password);
    }
}
