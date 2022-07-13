using Models;
using DataAccess;
using Sensitive;
using CustomExceptions;
using System;
using System.Data.SqlClient;

namespace Services;

public class AuthServices
{
    public static string connectionString = "Server=tcp:autumn-server.database.windows.net,1433;Initial Catalog=AutumnDB;Persist Security Info=False;User ID=supremeadmin;Password=" + SensitiveVariables.dbpassword + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public User LoginUser(string userName, string password)
    {
        // create temp user object to store data retrieved from DataAccess layer
        User wantsInside;
        try
        {
            // retrieve user from database using DataAccess method
            wantsInside = new UserRepository().GetUserByUserName(userName);
            // if password for parameter user matches password from database user
            if (wantsInside.password == password)
            // return user to UI layer
            {
                return wantsInside;
            }
            else
            {
                Console.WriteLine("Go away.");
                // throw custom exception if passwords don't match
                throw new InvalidCredentials();
            }
            // throw custom exception if user doesn't exist
            // if (user.userName)
            // {
            //     throw new ResourceNotFound();
            // }

        }
        // catch any exception thrown from DataAccess
        catch (InvalidCredentials e)
        {
            // if exception caught, throw to the UI layer 
            Console.WriteLine(e.Message);
            return new User();
        }

    }


    public User RegisterUser(string userName, string password, userRole userRole)
    {
        // will use CreateUser
        User thisUser = new User(userName, password, userRole);

        string putUserInDB = "insert into AutumnERS.users (userName, password, userRole) values (@userName, @password, @userRole);";

        SqlConnection makeConnection = new SqlConnection(connectionString);
        
        SqlCommand saveUser = new SqlCommand(putUserInDB, makeConnection);
        
        saveUser.Parameters.AddWithValue("@userName", thisUser.userName);
        saveUser.Parameters.AddWithValue("@password", thisUser.password);
        saveUser.Parameters.AddWithValue("@userRole", thisUser.userRoleToString(thisUser.userRole));
        //saveUser.Parameters.AddWithValue("@userRole", thisUser.userRoleString);

        User userWannabe = new UserRepository().GetUserByUserName(userName);
        // if password for parameter user matches password from database user
        if (userWannabe.userName != thisUser.userName)
        // return user to UI layer
        {
            try{
                makeConnection.Open();
                int itWorked = saveUser.ExecuteNonQuery();
                makeConnection.Close();
                if (itWorked != 0)
                {
                    Console.WriteLine("Welcome to our club, " + thisUser.userName + "!");
                    User userWhy = new UserRepository().GetUserByUserName(thisUser.userName);
                    return userWhy;
                }
                else
                {
                    Console.WriteLine("Sorry, you're not welcome in our club, " + thisUser.userName + ".");
                    throw new UsernameNotAvailable();
                }
            }
            catch (UsernameNotAvailable e)
            {
                Console.WriteLine(e.Message);
            }

            return new User();

        }



    return thisUser;
    }

}

