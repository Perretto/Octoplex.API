using Octoplex.Kernel;
using Octoplex.NFe.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Infra.Data.NFe
{
    //public class NFeRepository : INFeRepository
    //{       
    //    public async Task <string>GerarChaveAcessoNFe(int cUF, DateTime dtEmissao, string cnpjEmissor, int modelo, int serie, string numeroNFe, string codNum)
    //    {
    //        string chave = await Task.FromResult(cUF.ToString() + dtEmissao + cnpjEmissor.Trim() + string.Format("{0:D2}", modelo).Trim() +
    //            string.Format("{0:D3}", serie).Trim() + string.Format("{0:D9}", numeroNFe).Trim() + "1" + string.Format("{0:D9}", codNum).Trim());
    //        return chave;
    //        //sCodDv = Utilities.AssinarXML.DigitoModulo11(chave).ToString().Trim();
    //        //Mapping.ChaveAcesso strChave = new Mapping.ChaveAcesso();
    //        //strChave._strChaveAcesso = "NFe" + chave.Trim() + Crypto.AssinarXML.DigitoModulo11(chave).ToString().Trim();
    //        //return "NFe" + chave.Trim() + Crypto.AssinarXML.DigitoModulo11(chave).ToString().Trim();
    //    }

    //    public Task<Result<Exception, Domain.NFe.NFe>> GerarXMLNFe(Domain.NFe.NFe nfe)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
