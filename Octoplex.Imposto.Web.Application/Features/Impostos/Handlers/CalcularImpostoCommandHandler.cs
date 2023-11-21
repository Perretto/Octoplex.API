using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Impostos.Web.Application.Features.Impostos.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Web.Application.Features.Impostos.Handlers
{
    public class CalcularImpostoCommandHandler : IRequestHandler<ImpostoCalcularCommand, ImpostoCalculo>
    {
        private readonly IImpostosRepository _impostosRepository;
        public CalcularImpostoCommandHandler(IImpostosRepository impostosRepository)
        {
            _impostosRepository = impostosRepository;
        }
        public async Task<ImpostoCalculo> Handle(ImpostoCalcularCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_impostosRepository.CalcularImposto(request.CalculoImposto));

            if(result.IsFaulted)
            {
                return new ImpostoCalculo();
            }
            return result.Result;
        }
    }
}
