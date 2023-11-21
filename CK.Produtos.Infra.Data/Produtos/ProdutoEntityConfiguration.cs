using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Produtos.Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Octoplex.Produtos.Infra.Data
{
    public class ProdutoEntityConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Codigo).HasColumnName("Codigo").HasMaxLength(45);
            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(120);
            builder.Property(p => p.Vrcompra).HasColumnName("ValorCompra");
            builder.Property(p => p.Vrvista).HasColumnName("ValorVenda");
            builder.Property(p => p.Codigoanp).HasColumnName("CodigoAnp");
            builder.Property(p => p.Un).HasColumnName("Un");
            builder.Property(p => p.Validade).HasColumnName("Validade");
            builder.Property(p => p.Estq).HasColumnName("Estoque");
            builder.Property(p => p.Lucro).HasColumnName("Lucro");
            builder.Property(p => p.DtUltvenda).HasColumnName("DtUltvenda");
            builder.Property(p => p.Valultvenda).HasColumnName("Valultvenda");
            builder.Property(p => p.CodGru).HasColumnName("CodGru");
            builder.Property(p => p.EstMin).HasColumnName("EstMin");
            builder.Property(p => p.Forn1).HasColumnName("idFornecedor1");
            builder.Property(p => p.Forn2).HasColumnName("idFornecedor2");
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.IdEmp).HasColumnName("idEmpresa");
            builder.Property(p => p.ValorA).HasColumnName("ValorA");
            builder.Property(p => p.ValorB).HasColumnName("ValorB");
            builder.Property(p => p.IniPromo).HasColumnName("IniPromo");
            builder.Property(p => p.FimPromo).HasColumnName("FimPromo");
            builder.Property(p => p.Balanca).HasColumnName("Balanca");
            builder.Property(p => p.TeclaB).HasColumnName("TeclaBalanca");
            builder.Property(p => p.CodPf).HasColumnName("CodigoNoFornecedor");
            builder.Property(p => p.ImpCoz).HasColumnName("ImprimeCozinha");
            builder.Property(p => p.Guid).HasColumnName("GuidIntegracao");
            builder.Property(p => p.Tipo).HasColumnName("Tipo");
            builder.Property(p => p.DivForn).HasColumnName("DivForn");
            builder.Property(p => p.DtAlt).HasColumnName("DataAlteracao");

            //builder.ToTable("Impostos");

            builder.HasOne(p => p.Imposto); //160123
            builder.HasMany(p => p.Impostos); //160123 HasMany declara que produtos tem varios impostos
        }
    }
}
