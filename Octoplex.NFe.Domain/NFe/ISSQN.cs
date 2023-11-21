using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    //Grupo U. ISSQN
    /*
        Campos para cálculo do ISSQN na NF-e conjugada, onde 
        há a prestação de serviços sujeitos ao ISSQN e 
        fornecimento de peças sujeitas ao ICMS.
    */
    public class ISSQN
    {
        public decimal vBC { get; set; }
        public decimal vAliq { get; set; }
        public decimal vISSQN { get; set; }
        public string cMunFG { get; set; }
        public string cListServ { get; set; }
        public decimal vDeducao { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDescIncond { get; set; }
        public decimal vDescCond { get; set; }
        public decimal vISSRet { get; set; }
        public int indISS { get; set; }
        public string cServico { get; set; }
        public string cMun { get; set; }
        public int cPais { get; set; }
        public string nProcesso { get; set; }
        public int indIncentivo { get; set; }
    }
}
