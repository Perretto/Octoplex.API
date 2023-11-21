using Octoplex.Kernel;
using System;
using Octoplex.NFe.Domain.NFe;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.Interface
{
    public interface INFeRepository
    {
        Task <string> GerarChaveAcessoNFe(int cUF, DateTime dtEmissao, string cnpjEmissor, int modelo, int serie, string noNFe, string codNum);
        Task<Result<Exception, NFe.NFe>> GerarXMLNFe(NFe.NFe nfe);
    }
}
