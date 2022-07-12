using CustomExceptions;
using System.Data.SqlClient;

public class ConnectionFactory
{

    public static ConnectionFactory GetInstance()
    {
        throw new ResourceNotFound();
    }



    public SqlConnection GetConnection()
    {
        throw new ResourceNotFound();
    }

}