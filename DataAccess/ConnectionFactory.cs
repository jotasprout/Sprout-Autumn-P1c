using System.Data.SqlClient;

public class ConnectionFactory
{

    public static ConnectionFactory GetInstance()
    {
        return new User();
    }



    public SqlConnection GetConnection()
    {
        return new User();
    }

}