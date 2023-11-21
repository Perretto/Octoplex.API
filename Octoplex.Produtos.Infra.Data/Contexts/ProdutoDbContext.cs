using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Produtos.Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Octoplex.Produtos.Infra.Data.Contexts
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> opcoes) : base(opcoes)
        {
            TryApplyMigration(opcoes);
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Imposto> Impostos { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new ProdutoEntityConfiguration());
            base.OnModelCreating(model);
        }

        private void TryApplyMigration(DbContextOptions<ProdutoDbContext> options)
        {
            var inMemoryConfiguration = options.Extensions.FirstOrDefault(x => x.ToString().Contains("InMemoryOptionsExtension"));

            if (inMemoryConfiguration == null && Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }
    }
}
