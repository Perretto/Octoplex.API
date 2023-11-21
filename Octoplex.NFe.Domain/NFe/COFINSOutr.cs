using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    /*
        49=Outras Operações de Saída;
        50=Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno;
        51=Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno;
        52=Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação;
        53=Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno;
        54=Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação;
        55=Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação;
        56=Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de 
        Exportação;
        60=Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno;
        61=Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado 
        Interno;
        62=Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação;
        63=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno;
        64=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação;
        65=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de
        Exportação;
        66=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, 
        e de Exportação;
        67=Crédito Presumido - Outras Operações;
        70=Operação de Aquisição sem Direito a Crédito;
        71=Operação de Aquisição com Isenção;
    */
    public class COFINSOutr
    {
        public int CST { get; set; }
        public decimal vBC { get; set; }
        public decimal pCOFINS { get; set; }
        public decimal qBCProd { get; set; }
        public decimal vAliqProd { get; set; }
        public decimal vCOFINS { get; set; }
    }
}
