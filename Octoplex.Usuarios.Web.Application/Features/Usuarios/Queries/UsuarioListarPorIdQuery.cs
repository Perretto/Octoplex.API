using Octoplex.Usuarios.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Web.Application.Features.Usuarios.Queries
{
    public class UsuarioListarPorIdQuery : IRequest<Usuario>
    {
        public int Id { get; set; }
    }
}
