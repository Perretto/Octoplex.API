using Octoplex.Produtos.Infra.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Octoplex.Produtos.WebAPI.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection UseDbContext<T>(this IServiceCollection service, IConfiguration configuration) where T : DbContext
        {
            //Registrando ums instancia do Contexto default
            //Criado para ser utilizado pelo Mediator
            var result = (configuration.GetConnectionString("DefaultConnection"), service);
            service.AddDbContext<T>(options => options.UseSqlServer(result.Item1.ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            return service;
        }

        public static void ApplyMigrations(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var database = scope.ServiceProvider.GetRequiredService<ProdutoDbContext>().Database;
                if (database.IsThereMigrationsToApply())
                    database.Migrate();
            }
        }

        public static bool IsThereMigrationsToApply(this DatabaseFacade db)
        {
            var migrationsAssembly = db.GetService<IMigrationsAssembly>();
            var historyRepository = db.GetService<IHistoryRepository>();

            var all = migrationsAssembly.Migrations.Keys;
            var applied = historyRepository.GetAppliedMigrations().Select(r => r.MigrationId);
            var pending = all.Except(applied);

            return pending.Count() > 0;
        }

        //public EmpresaDbContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<EmpresaDbContext>();
        //    optionsBuilder.UseSqlServer("server=localhost;Database=BDCK;Trusted_Connection=True;MultipleActiveResultSets=true;App=EntityFramework");

        //    return new EmpresaDbContext(optionsBuilder.Options);
        //}
    }
}
