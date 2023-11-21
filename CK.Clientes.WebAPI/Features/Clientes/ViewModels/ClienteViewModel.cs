//using Octoplex.Pedidos.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octoplex.WebAPI.Features.Clientes.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public int Lanca { get; set; }
        public string NomeCliente { get; set; }
        public string Fantasia { get; set; }
        public string CnpjCpf { get; set; }
        public string InscRg { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Uf { get; set; }
        public string CodCidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Fone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public string Obs { get; set; }
        public int EnvEmail { get; set; }
        public string Suframa { get; set; }
        public double Pontos { get; set; }
        public int Convenio { get; set; }
        public int IdEmp { get; set; }
        public string Tipo { get; set; }
        public double Credito { get; set; }
        public string DtNasc { get; set; }
        public int VctoFixo { get; set; }
        public int IndIeDest { get; set; }
        public string Guid { get; set; }
        public string DtAlt { get; set; }
       // public IList<Pedido> Pedidos { get; set; }
    }
}
