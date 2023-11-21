using Octoplex.Impostos.Domain.Impostos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Web.Application.Features.Impostos.Commands
{
    public class ImpostoCalcularCommand : IRequest<ImpostoCalculo>
    {
        public ImpostoCalcularCommand(ImpostoCalculo impostoCalculo)
        {
            CalculoImposto = impostoCalculo;
        }
        public ImpostoCalculo CalculoImposto { get; set; }

        public ImpostoCalculo Calcular() => CalculoImposto.CalcularImpostoProduto();
       
    }
}
