using MediatR;
using Octoplex.NFe.Domain.NFe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Web.Application.Features.NFe.Commands
{
    public class NFeCommand : IRequest<Domain.NFe.NFe>
    {
        public NFeCommand(Domain.NFe.NFe nFe)
        {
            NFe = nFe;
            ChaveAcesso = nFe.infNFe.Id;
            NumeroNFe = nFe.infNFe.ide.nNF.ToString();
        }
        public string ChaveAcesso { get; set; }
        public string NumeroNFe { get; set; }
        public Domain.NFe.NFe NFe { get; set; }
    }
}
