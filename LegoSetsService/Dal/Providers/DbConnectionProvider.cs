using System.Data.Common;
using System.Data.SqlClient;

namespace LegoSetsService.Dal.Providers
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly string connectionString;

        public DbConnectionProvider(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:LegoSetsServiceConnectionString"];
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
