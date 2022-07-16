using System;
using Services;
using Models;
using DataAccess;
using CustomExceptions;

namespace UI
{
    public class ManagerMainMenu
    {
        public void DisplayManagerMainMenu(User CurrentUserIn)
        {
            Console.WriteLine("Manage:");
            Console.WriteLine("[1] Employees");
            Console.WriteLine("[2] Tickets");                     
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {
                case "1": // Employees
                    Console.WriteLine("Here is a list of all users:");
                    UserRepository peeps = new UserRepository();
                    peeps.GetAllUsers();
                    break;                 
                case "2": // Tickets
                    Console.WriteLine("Here are all your tickets:");
                    TicketRepository myTickets = new TicketRepository();
                    int myIDint = CurrentUserIn.userID;
                    string myIDstring = myIDint.ToString();
                    myTickets.GetTicketsByUserID(myIDstring);
                    break;                  
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            //Environment.Exit(0);
        }
    }
}