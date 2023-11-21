using System;

namespace Octoplex.Pedidos.WebAPI.Features.Pedidos
{
    public class ListPedidosViewModel
    {
        public Nullable<Guid> Id { get; set; }
        public double Total { get; set; }
    }
}
