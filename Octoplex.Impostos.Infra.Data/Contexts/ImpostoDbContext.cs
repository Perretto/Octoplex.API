using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Impostos.Infra.Data.Impostos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Impostos.Infra.Data.Contexts
{
    public class ImpostoDbContext : DbContext
    {
        public ImpostoDbContext(DbContextOptions<ImpostoDbContext> opcoes) : base(opcoes)
        {
            //TryApplyMigration(opcoes);
        }
        public DbSet<Imposto> Impostos { get; set; }
        //public DbSet<ImpostoCalculo> impostoCalculos { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfiguration(new ImpostoEntityConfiguration());
        }

        private void TryApplyMigration(DbContextOptions<ImpostoDbContext> options)
        {
            try
            {
                var inMemoryConfiguration = options.Extensions.FirstOrDefault(x => x.ToString().Contains("InMemoryOptionsExtension"));

                if (inMemoryConfiguration == null && Database.GetPendingMigrations().Count() > 0)
                    Database.Migrate();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
