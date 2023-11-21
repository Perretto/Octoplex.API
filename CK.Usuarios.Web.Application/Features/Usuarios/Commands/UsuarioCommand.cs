using Octoplex.Usuarios.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Web.Application.Features.Usuarios.Commands
{
    public class UsuarioCommand : IRequest<Usuario>
    {
        public UsuarioCommand(Usuario user)
        {
            Usuario = user;            
        }
        public Usuario Usuario { get; set; }
    }
}
