using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    public class enderEmit
    {
        [Required(ErrorMessage="Informe o Logradouro")]
        [StringLength(60, MinimumLength = 2)]
        public string xLgr { get; set; }

        [Required(ErrorMessage = "Informe o Numero")]
        public string nro { get; set; }

        public string xCpl { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [StringLength(60, MinimumLength = 2)]
        public string xBairro { get; set; }

        public int cMun { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Municipio")]
        [StringLength(60, MinimumLength = 2)]
        public string xMun { get; set; }

        [Required(ErrorMessage = "Informe a UF")]
        [StringLength(2, MinimumLength = 2)]
        public string UF { get; set; }

        [Required(ErrorMessage = "Informe o Cep")]
        [StringLength(8, MinimumLength = 8)]
        public string CEP { get; set; }

        public int cPais { get; set; } = 1058;
        public string xPais { get; set; } = "BRASIL";
        public string fone { get; set; }
        public string IE { get; set; }
        public string IEST { get; set; }
        public string IM { get; set; }
        public string CNAE { get; set; }
        public int CRT { get; set; }
    }
}
