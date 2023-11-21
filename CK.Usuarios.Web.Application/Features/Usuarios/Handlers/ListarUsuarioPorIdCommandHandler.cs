using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Web.Application.Features.Usuarios.Handlers
{
    public class ListarUsuarioPorIdCommandHandler : IRequestHandler<UsuarioListarPorIdQuery, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public ListarUsuarioPorIdCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario> Handle(UsuarioListarPorIdQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await Task.FromResult(_usuarioRepository.ObterPorIdAsync(request.Id));
            if (usuarios.IsFaulted)
            {
                return null;
            }
            return usuarios.Result.Success;
        }
    }
}
