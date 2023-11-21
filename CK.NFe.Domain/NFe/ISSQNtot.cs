using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo W01. Total da NF-e / ISSQN
    public class ISSQNtot
    {
        public decimal vServ { get; set; }
        public decimal vBC { get; set; }
        public decimal vISS { get; set; }
        public decimal vPIS { get; set; }
        public decimal vCOFINS { get; set; }
        public DateTime dCompet { get; set; }
        public decimal vDeducao { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDescIncond { get; set; }
        public decimal vDescCond { get; set; }
        public decimal vISSRet { get; set; }
        public decimal cRegTrib { get; set; }
    }
}
