using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Web.Application.Features.Usuarios.Handlers
{
    public class AdicionarUsuarioCommandHandler : IRequestHandler<UsuarioCommand, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AdicionarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Handle(UsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_usuarioRepository.Adicionar(request.Usuario));
            if (result.IsFaulted)
            {
                return null;
            }
            return result.Result.Success;
        }
    }
}
