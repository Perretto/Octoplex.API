using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo G. Identificação do Local de Entrega
    public class entrega
    {
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(60, MinimumLength = 2)]
        public string xNome { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro")]
        [StringLength(60, MinimumLength = 2)]
        public string xLgr { get; set; }

        public string nro { get; set; }
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public int cMun { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; } 
        public string cPais { get; set; }
        public string xPais { get; set; }
        public string fone { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string email { get; set; }
    }
}
