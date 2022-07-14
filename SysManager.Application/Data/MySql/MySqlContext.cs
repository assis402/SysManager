using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace SysManager.Application.Data.MySql
{
    public class MySqlContext
    {
        private MySqlConnection connection;
        private readonly string connectionString = "";

        public MySqlContext()
        {
        }

        public MySqlContext(IOptions<AppConnectionSettings> appSettings)
        {
            connectionString = appSettings.Value.DefaultConnection;
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public MySqlConnection Connection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}