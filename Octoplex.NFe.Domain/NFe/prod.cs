using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo I. Produtos e Serviços da NF-e
    public class prod
    {
        [Required(ErrorMessage = "Informe o Codigo do Produto")]
        [StringLength(60, MinimumLength = 1)]
        public string cProd { get; set; }
        public string cEAN { get; set; }

        [Required(ErrorMessage = "Informe a Descrição do Produto")]
        [StringLength(120, MinimumLength = 1)]
        public string xProd { get; set; }
        
        public int NCM { get; set; }
        public string NVE { get; set; }
        public int CEST { get; set; }
        public string indEscala { get; set; }
        public string CNPJFab { get; set; }
        public string cBenef { get; set; }
        public int EXTIPI { get; set; }
        public int CFOP { get; set; }
        public string uCom { get; set; }
        public decimal qCom { get; set; }
        public decimal vUnCom { get; set; }
        public decimal vProd { get; set; }
        public string cEANTrib { get; set; }
        public string uTrib { get; set; }
        public decimal qTrib { get; set; }
        public decimal vUnTrib { get; set; }
        public decimal vFrete { get; set; }
        public  decimal vSeg { get; set; }
        public decimal vDesc { get; set; }
        public decimal vOutro { get; set; }
        public int indTot { get; set; }
    }
}
