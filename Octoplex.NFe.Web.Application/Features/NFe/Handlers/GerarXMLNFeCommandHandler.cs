using Octoplex.NFe.Web.Application.Features.NFe.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octoplex.NFe.Web.Application.Features.NFe.Handlers
{
    public class GerarXMLNFeCommandHandler : IRequestHandler<NFeCommand, Domain.NFe.NFe>
    {
        public Task<Domain.NFe.NFe> Handle(NFeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
