namespace ProjectStartUp.Connection
{
    public class ConnectionString
    {
        private readonly string _connectionString;

        public ConnectionString()
        {
            _connectionString = "Data Source=LAPTOP-3BNGUHJN\\SQLEXPRESS;Initial Catalog=PS00001;Integrated Security=True;Encrypt=False";
        }

        
        public string GetConnectionString()
        {
            return _connectionString;
        }

       
    }
}
