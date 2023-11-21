using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Queries;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Web.Application.Features.Usuarios.Handlers
{
    public class ListarUsuarioCommandHandler : IRequestHandler<UsuarioListarQuery, IQueryable<Usuario>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public ListarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IQueryable<Usuario>> Handle(UsuarioListarQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await Task.FromResult(_usuarioRepository.Listar());
            if (usuarios.IsFailure)
            {
                return null;
            }
            return usuarios.Success;
        }
    }
}
