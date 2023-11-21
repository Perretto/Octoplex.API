using Octoplex.Usuarios.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Infra.Data.Usuarios
{
    public  class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(e => e.Id).HasName("pkUsuario");
            builder.Property(e => e.Username).HasColumnName("Nome").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Password).HasColumnName("Senha").HasMaxLength(40).IsRequired();
            builder.Property(e => e.Role).HasColumnName("Role").HasMaxLength(100).IsRequired();
        }
    }
}
