using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octoplex.Empresas.Domain.Empresas
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string IeRg { get; set; }
        public string InscMunicipal { get; set; }
        public  int Crt { get; set; }
        public string ChavePrivada { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public void ObterDataAlteracao() => DataAlteracao = DateTime.Now;
    }
}
