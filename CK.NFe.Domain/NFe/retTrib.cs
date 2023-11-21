using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo W02. Total da NF-e / Retenção de Tributos
    /*
        Exemplos de atos normativos que definem Obrigatoriedade da retenção de contribuições:
        a) IRPJ/CSLL/PIS/COFINS - Fonte - Recebimentos de Órgão Público Federal, Lei nº 9.430, de 27 de dezembro de 1996, art. 64, Lei nº 10.833/2003, art. 
        34, como normas infralegais, temos como exemplo: IN SRF 480/2004 e IN 539, de 25/04/05.
        b) Retenção do Imposto de Renda pelas Fontes Pagadoras, REMUNERAÇÃO DE SERVIÇOS PROFISSIONAIS PRESTADOS POR PESSOA JURÍDICA, 
        Lei nº 7.450/85, art. 52
        c) IRPJ, CSLL, COFINS e PIS - Serviços Prestados por Pessoas Jurídicas - Retenção na Fonte, Lei nº 10.833 de 29.12.2003, art. 30, 31, 32, 35 e 36
    */
    public class retTrib
    {
        public decimal vRetPIS { get; set; }
        public decimal vRetCOFINS { get; set; }
        public decimal vRetCSLL { get; set; }
        public decimal vBCIRRF { get; set; }
        public decimal vIRRF { get; set; }
        public decimal vBCRetPrev { get; set; }
        public decimal vRetPrev { get; set; }
    }
}
