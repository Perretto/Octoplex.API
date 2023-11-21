using Octoplex.Kernel;
using Octoplex.Usuarios.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Web.Application.Features.Usuarios.Queries
{
    //public class UsuarioListarQuery : IRequest<Result<Exception, IQueryable<Usuario>>>
    public class UsuarioListarQuery : IRequest<IQueryable<Usuario>>
    {

    }
}
