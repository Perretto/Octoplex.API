using Octoplex.Pedidos.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Pedidos.Infra.Data.Pedidos
{
    public class PedidoEntityConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey("Id");
            builder.Property(p => p.Total).HasColumnName("TotalPedido");
        }
    }
}
