using Octoplex.Impostos.Domain.Impostos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Web.Application.Features.Impostos.Commands
{
    public class ImpostoCommand : IRequest<Imposto>
    {
        public ImpostoCommand(Imposto imposto)
        {
            Imposto = imposto;
        }
        public Imposto Imposto { get; set; }
    }
}
