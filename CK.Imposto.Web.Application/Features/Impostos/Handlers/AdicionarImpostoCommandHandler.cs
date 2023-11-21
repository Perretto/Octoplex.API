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
    public class AdicionarImpostoCommandHandler : IRequestHandler<ImpostoCommand, Imposto>
    {
        private readonly IImpostosRepository _impostosRepository;
        public AdicionarImpostoCommandHandler(IImpostosRepository impostosRepository)
        {
            _impostosRepository = impostosRepository;
        }
        public async Task<Imposto> Handle(ImpostoCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_impostosRepository.Adicionar(request.Imposto));
            if (result.IsFaulted)
            {
                return new Imposto();
            }
            return result.Result.Success;
        }
    }
}
