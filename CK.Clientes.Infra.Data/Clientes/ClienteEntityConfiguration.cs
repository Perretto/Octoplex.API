using Octoplex.Clientes.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Octoplex.Clientes.Infra.Data
{
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id).HasName("id");
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(c => c.Lanca).HasColumnName("lanca");
            builder.Property(c => c.NomeCliente).HasColumnName("Nome").HasMaxLength(100);
            builder.Property(c => c.Fantasia).HasColumnName("NomeFantasia").HasMaxLength(120);
            builder.Property(c => c.CnpjCpf).HasColumnName("CnpjCpf").HasMaxLength(18);
            builder.Property(c => c.InscRg).HasColumnName("IeRg").HasMaxLength(18);
            builder.Property(c => c.Obs).HasColumnName("Observacao").HasMaxLength(500);
            builder.Property(c => c.EnvEmail).HasColumnName("EnviaEmail");
            builder.Property(c => c.Pontos).HasColumnName("Pontos");
            builder.Property(c => c.IdEmp).HasColumnName("IdEmpresa");
            builder.Property(c => c.Tipo).HasColumnName("TipoCadastro");
            builder.Property(c => c.Credito).HasColumnName("Credito");
            builder.Property(c => c.DtNasc).HasColumnName("DataNascimento");
            builder.Property(c => c.VctoFixo).HasColumnName("VencimentoFixo");
            builder.Property(c => c.IndIeDest).HasColumnName("IndicadorIE");
            builder.Property(c => c.DtAlt).HasColumnName("DataAlteracao");
            builder.Property(c => c.Guid).HasColumnName("GuidIntegracaoNet");
            //builder.Property(c => c.Pedidos).HasColumnName("ListaPedidos");
        }
    }
}
