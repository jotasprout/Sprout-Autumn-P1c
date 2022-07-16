using CustomExceptions;
using System.Data.SqlClient;

// namespace DataAccess
// {
    public class ConnectionFactory
    {

        private static ConnectionFactory? instanceThing;
        private readonly string connectionThing;

        private ConnectionFactory(string connectionThingArg)
        {
            connectionThing = connectionThingArg;
        }

        public static ConnectionFactory GetInstance(string connectionThingArg)
        {
            if(instanceThing == null)
            {
                instanceThing = new ConnectionFactory(connectionThingArg);
            }
            return instanceThing;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionThing);
        }

    }
// }
