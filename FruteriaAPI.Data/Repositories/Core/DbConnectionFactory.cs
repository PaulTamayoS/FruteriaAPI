using System.Data;
using System.Data.SqlClient;

namespace FruteriaAPI.Data.Repositories.Core
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;
        internal IDbConnection Connection => new SqlConnection(_connectionString);
        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
