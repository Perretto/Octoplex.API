using System;

namespace Octoplex.Pedidos.WebAPI.Features.ViewModels
{
    public class PedidoViewModel
    {
        public Nullable<Guid> Id { get; set; }
        public double Total { get; set; }
    }
}
