namespace ProjectStartUp.Connection
{
    public class ConnectionString
    {
        private readonly string _connectionString;

        // Constructor to initialize the connection string
        public ConnectionString()
        {
            _connectionString = "Data Source=LAPTOP-3BNGUHJN\\SQLEXPRESS;Initial Catalog=PS00001;Integrated Security=True;Encrypt=False";
        }

        // ✅ Property to expose the connection string
        public string GetConnectionString()
        {
            return _connectionString;
        }

        // (your existing ExecuteSqlCommand code stays here…)
    }
}
