using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Infra.Data.Usuarios;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Octoplex.Usuarios.Infra.Data.Contexts
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opcoes) : base(opcoes)
        {
            //TryApplyMigration(opcoes);
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfiguration(new UsuarioEntityConfiguration());
        }

        private void TryApplyMigration(DbContextOptions<UsuarioDbContext> options)
        {
            var inMemoryConfiguration = options.Extensions.FirstOrDefault(x => x.ToString().Contains("InMemoryOptionsExtension"));

            if (inMemoryConfiguration == null && Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }
    }
}
