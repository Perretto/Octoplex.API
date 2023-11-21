using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace Octoplex.Produtos.Infra.Data
{
    public class DBSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DBSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose(); 
        
    }
}
