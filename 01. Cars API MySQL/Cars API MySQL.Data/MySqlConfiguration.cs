namespace Cars_API_MySQL.Data
{
    public class MySqlConfiguration
    {
        public MySqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
    }
}
