
namespace EdenFreshApplication
{
     class connection
    {
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=logging;Integrated Security=True;Pooling=False";
        public static string getConnectionString()
        {
            return connectionString;
        }
    }
}
