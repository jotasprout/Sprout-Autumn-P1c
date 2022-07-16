using Models;
using Sensitive;
// using Services;
using CustomExceptions;
using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserRepository
    {

        public string thoseAll = "select * from AutumnERS.users;";

        public static string THISWASMYCONNECTIONSTRING = "Server=tcp:autumn-server.database.windows.net,1433;Initial Catalog=AutumnDB;Persist Security Info=False;User ID=supremeadmin;Password=" + SensitiveVariables.dbpassword + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private readonly ConnectionFactory connectionThing;

        public UserRepository()
        {
            connectionThing = ConnectionFactory.GetInstance(File.ReadAllText("../Sensitive/connectionString.txt"));
        }

        public List<User> GetUsers(string those)
        {

            List<User> users = new List<User>();
            User tempUserHoldingRole = new User();

            SqlConnection makeConnection = connectionThing.GetConnection();
            SqlCommand getEveryUser = new SqlCommand(those, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = getEveryUser.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);
                    int RoleFromDB = tempUserHoldingRole.userRoleToInt((string)reader[3]); 
                    users.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (userRole)RoleFromDB));
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return users;
        }


        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            GetUsers(thoseAll);
            return allUsers;
        }


        public User GetUserByUserName(string userWanted)
        {

            User thisUser = new User();
            User tempUserHoldingRole = new User();

            string getThisUser = "select * from AutumnERS.users where userName ='" + userWanted + "';";

            SqlConnection makeConnection = connectionThing.GetConnection();
            SqlCommand goGetThisUser = new SqlCommand(getThisUser, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = goGetThisUser.ExecuteReader();
                while (reader.Read())
                {
                    int RoleFromDB = tempUserHoldingRole.userRoleToInt((string)reader[3]); 
                    thisUser = new User((int)reader[0], (string)reader[1], (string)reader[2], (userRole)RoleFromDB);
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return thisUser;
        }





        public User GetUserByUserID(string userID)
        {
            User thisUser = new User();
            User tempUserHoldingRole = new User();

            string getThisUser = "select * from AutumnERS.users where userID ='" + userID + "';";

            SqlConnection makeConnection = connectionThing.GetConnection();
            SqlCommand goGetThisUser = new SqlCommand(getThisUser, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = goGetThisUser.ExecuteReader();
                while (reader.Read())
                {
                    int RoleFromDB = tempUserHoldingRole.userRoleToInt((string)reader[3]); 
                    thisUser = new User((int)reader[0], (string)reader[1], (string)reader[2], (userRole)RoleFromDB);
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return thisUser;
        }

    }
}

