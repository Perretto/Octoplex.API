using System;

namespace Octoplex.Empresas.WebAPI.Features.Empresas.ViewModels
{
    public class EmpresaViewModel
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string IeRg { get; set; }
        public string InscMunicipal { get; set; }
        public int Crt { get; set; }
        public string ChavePrivada { get; set; }
    }
}
