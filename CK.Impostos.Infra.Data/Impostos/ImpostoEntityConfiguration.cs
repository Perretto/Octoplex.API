using Octoplex.Impostos.Domain.Impostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Octoplex.Impostos.Infra.Data.Impostos
{
    public class ImpostoEntityConfiguration : IEntityTypeConfiguration<Imposto>
    {
        public void Configure(EntityTypeBuilder<Imposto> builder)
        {
            builder.ToTable("Impostos");
            builder.HasKey(i => i.IdImposto);
            builder.Property(i => i.IdProduto);
            builder.Property(i => i.Cest).HasColumnName("Cest");
            builder.Property(i => i.Cfop).HasColumnName("Cfop");
            builder.Property(i => i.Ncm).HasColumnName("Ncm");
            builder.Property(i => i.Origem).HasColumnName("Origem");
            builder.Property(i => i.CstIcms).HasColumnName("CstIcms");
            builder.Property(i => i.AliqIcms).HasColumnName("AliqIcms");
            builder.Property(i => i.Csosn).HasColumnName("Csosn");
            builder.Property(i => i.CstIpi).HasColumnName("CstIpi");
            builder.Property(i => i.AliqIpi).HasColumnName("AliqIpi");
            builder.Property(i => i.CstPis).HasColumnName("CstPis");
            builder.Property(i => i.AliqPis).HasColumnName("AliqPis");
            builder.Property(i => i.CstCofins).HasColumnName("CstCofins");
            builder.Property(i => i.AliqCofins).HasColumnName("AliqCofins");
            builder.Property(i => i.CodigoSefaz).HasColumnName("CodigoSefaz");
            builder.Property(i => i.IbptAliq).HasColumnName("IbptAliq");
            builder.Property(i => i.CodigoUf).HasColumnName("CodigoUf");
        }
    }
}
