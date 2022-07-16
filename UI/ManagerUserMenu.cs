using System;
using Services;
using Models;
using DataAccess;
using CustomExceptions;

namespace UI
{
    public class ManagerUserMenu
    {
        private static UserServices _user;
        public ManagerUserMenu()
        {
            _user = new UserServices(new IuserDAO(new UserRepository()));
        }
        
        public void DisplayManagerUserMenu(User CurrentUserIn)
        {
            Console.WriteLine("Find:");
            Console.WriteLine("[1] All Employees");
            Console.WriteLine("[2] An Employee by UserName");
            Console.WriteLine("[3] An Employee by UserID");                         
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {         
                case "1": // View Entire User List
                    Console.WriteLine("Here is a list of all users:");
                    UserRepository peeps = _user;
                    peeps.GetAllUsers();
                    break;   
                case "2": // View Users by UserName
                    Console.WriteLine("Which user do you want?");
                    string userNameIWant = Console.ReadLine();
                    UserRepository PeepIWant = _user;
                    PeepIWant.GetUsersByUserName(userNameIWant);
                    break;            
                case "3": // View Users by UserID
                    Console.WriteLine("Enter userID.");
                    string userIDfor = Console.ReadLine();
                    UserRepository ThisUserID = _user;
                    ThisUserID.GetUsersByUserID(userIDfor);
                    break;                                         
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            //Environment.Exit(0);
        }

    }
}