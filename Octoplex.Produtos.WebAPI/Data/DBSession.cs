using Microsoft.Data.SqlClient;
using System.Data;

namespace Octoplex.Produtos.WebAPI.Data
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
