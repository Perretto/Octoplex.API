using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Domain.Pedidos
{
    public class Pedido
    {
        public Nullable<Guid> Id { get; set; }
        public string NumeroPedido { get; set; }
        public double Total { get; set; }
    }
}
