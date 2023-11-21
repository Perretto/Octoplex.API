using Octoplex.Empresas.Infra.Data.Empresas;
using Octoplex.Empresas.Domain.Empresas;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Octoplex.Empresas.Infra.Data.Contexts
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions<EmpresaDbContext> opcoes) : base(opcoes)
        {
            //TryApplyMigration(opcoes);
        }

        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfiguration(new EmpresaEntityConfiguration());
        }
     
        private void TryApplyMigration(DbContextOptions<EmpresaDbContext> options)
        {
            var inMemoryConfiguration = options.Extensions.FirstOrDefault(x => x.ToString().Contains("InMemoryOptionsExtension"));

            if (inMemoryConfiguration == null && Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }
    }
}
