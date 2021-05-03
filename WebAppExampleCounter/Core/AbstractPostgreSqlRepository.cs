using Dapper;
using Npgsql;
using System.Threading.Tasks;

namespace WebAppExampleCounter.Core
{
    public class AbstractPostgreSqlRepository
    {
        private readonly NpgsqlConnectionStringBuilder _connectionStringBuilder;

        public AbstractPostgreSqlRepository(PostgreSqlConfiguration configOptions)
        {
            var configuration = configOptions;
            _connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = configuration.Host,
                Username = configuration.Username,
                Password = configuration.Password,
                Database = configuration.Database,
                Pooling = configuration.Pooling,
                Port = configuration.Port,
                CommandTimeout = 60,
                Timeout = 30,
                MinPoolSize = 20,
                MaxPoolSize = 200,
                ConnectionIdleLifetime = 600,
                ConnectionPruningInterval = 5,
                ClientEncoding = "UTF8",
                Encoding = "UTF8",
            };
        }


        public NpgsqlConnection GetSqlConnection() => new NpgsqlConnection(_connectionStringBuilder.ConnectionString);

        public async Task<T> QueryFirstAsync<T>(string sql, object parameters = null)
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryFirstAsync<T>(sql.AddMetaDataToSqlRequest(), parameters);
        }


        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            await using var connection = GetSqlConnection();
            await connection.OpenAsync();
            return await connection.ExecuteAsync(sql.AddMetaDataToSqlRequest(), parameters);
        }

        public async void ExecuteSql(string sql, object parameters)
        {
            await using (var connection = GetSqlConnection())
            {
                var affectedRows = connection.ExecuteAsync(sql, parameters).Result;
            }
        }
    }

    public static class Extensions
    {
        public static string AddMetaDataToSqlRequest(this string sql) =>
            sql.Trim().StartsWith("SELECT") ? sql : sql.Insert(0, "/REPLICATION/ ");
    }
}