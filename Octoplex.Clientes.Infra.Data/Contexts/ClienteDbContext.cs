using Octoplex.Clientes.Domain.Clientes;
//using Octoplex.Pedidos.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Octoplex.Clientes.Infra.Data.Contexts
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> opcoes) : base(opcoes)
        {
            TryApplyMigration(opcoes);
        }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfiguration(new ClienteEntityConfiguration());
        }

        private void TryApplyMigration(DbContextOptions<ClienteDbContext> options)
        {
            var inMemoryConfiguration = options.Extensions.FirstOrDefault(x => x.ToString().Contains("InMemoryOptionsExtension"));

            if (inMemoryConfiguration == null && Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }
    }
}
