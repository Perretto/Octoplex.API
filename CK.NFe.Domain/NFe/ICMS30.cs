using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N05. Grupo Tributação do ICMS= 30
    public class ICMS30
    {
        public int orig { get; set; }
        public int CST { get; set; }
        public int modBCST { get; set; }
        public decimal pMVAST { get; set; }
        public decimal pRedBCST { get; set; }
        public decimal vBCST { get; set; }
        public decimal pICMSST { get; set; }
        public decimal vICMSST { get; set; }
        public decimal vBCFCPST { get; set; }
        public decimal pFCPST { get; set; }
        public decimal vFCPST { get; set; }
        
        //4.0
        //Informar apenas nos motivos de desoneração documentados abaixo.
        public string vICMSDeson { get; set; }

        //4.0
        //Campo será preenchido quando o campo anterior estiver preenchido. 
        //Informar o motivo da desoneração
        //3=Uso na agropecuária
        //9=Outros
        //12=Órgão de fomento e desenvolvimento agropecuário
        public int motDesICMS { get; set; }
    }
}
