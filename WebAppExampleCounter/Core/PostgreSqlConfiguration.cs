namespace WebAppExampleCounter.Core
{
    public class PostgreSqlConfiguration
    {
        public string Host { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Database { get; set; }

        public bool Pooling { get; set; }

        public int Port { get; set; }
    }
}