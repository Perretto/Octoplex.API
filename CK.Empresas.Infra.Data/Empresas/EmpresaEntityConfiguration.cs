using Octoplex.Empresas.Domain.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Octoplex.Empresas.Infra.Data.Empresas
{
    public class EmpresaEntityConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");
            builder.HasKey(e => e.Id).HasName("pkEmpresas");
            builder.Property(e => e.NomeFantasia).HasColumnName("NomeFantasia").HasMaxLength(100).IsRequired();
            builder.Property(e => e.RazaoSocial).HasColumnName("RazaoSocial").HasMaxLength(120).IsRequired();
            builder.Property(e => e.CpfCnpj).HasColumnName("CpfCnpj").HasMaxLength(20).IsRequired();
            builder.Property(e => e.IeRg).HasColumnName("IeRg").HasMaxLength(18).IsRequired();
            builder.Property(e => e.InscMunicipal).HasColumnName("InscMunicipal").HasMaxLength(18);
            builder.Property(e => e.Crt).HasColumnName("RegimeTributario").HasMaxLength(1).IsRequired();
            builder.Property(e => e.ChavePrivada).HasColumnName("ChavePrivada").HasMaxLength(50);
        }
    }
}
