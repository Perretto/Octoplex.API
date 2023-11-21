using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N04. Grupo Tributação do ICMS= 20
    public class ICMS20
    {
        public int Orig { get; set; }

        public int CST { get; set; }

        public int modBC { get; set; }

        public decimal pRedBC { get; set; }

        public decimal vBC { get; set; }

        public decimal pICMS { get; set; }

        public decimal vICMS { get; set; }

        public decimal modBCST { get; set; }

        public decimal vBCST { get; set; }

        public decimal pICMSST { get; set; }

        public decimal vICMSST { get; set; }

        //4.0
        public decimal vBCFCP { get; set; }

        //4.0
        public decimal pFCP { get; set; }

        //4.0
        public decimal vFCP { get; set; }

        //4.0
        //Informar apenas nos motivos de desoneração documentados abaixo.
        public decimal vICMSDeson { get; set; }

        //4.0
        //Campo será preenchido quando o campo anterior estiver preenchido. 
        //Informar o motivo da desoneração
        //3=Uso na agropecuária
        //9=Outros
        //12=Órgão de fomento e desenvolvimento agropecuário
        public int motDesICMS { get; set; }

    }
}
