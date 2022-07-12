using System;
using Services;
using Models;
using DataAccess;

namespace UI
{
    public class MainMenu
    {
        public void Begin()
        {
            do
            {
                Console.WriteLine("Welcome to AutumnERS, where expenses are as beautiful as Autumn leaves.");
                Console.WriteLine("What do you need to do?");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Register");
                Console.WriteLine("[3] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": // Login
                        DisplayLoginUI();
                        break;
                    case "2": // register
                        DisplayRegisterUI();
                        break;
                    case "3": // Exit
                        Console.WriteLine("Goodbye.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("What kind of nonsense was that?");
                        break;
                }
            } while (true);
        }

        public void DisplayLoginUI()
        {
            Console.WriteLine("userName: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Password, too: ");
            string password = Console.ReadLine();
            // Console.WriteLine("userName: " + userName + ", password: " + password);
            // Environment.Exit(0);
            User userKnocking = new AuthServices().LoginUser(userName, password);
            Console.WriteLine(userKnocking.userName + " is a " + userKnocking.userRole + ".");
            if (userKnocking.userRole == userRole.Manager)
            {
                Console.WriteLine("Show Manager stuff.");
                DisplayManagerMenu();
            }
            else {
                DisplayEmployeeMenu();
            }
            // Environment.Exit(0);
        }

        public void DisplayRegisterUI()
        {
            Console.WriteLine("Choose a userName");
            string maybeUserName = Console.ReadLine();
            Console.WriteLine("You typed " + maybeUserName + ".");
            Console.WriteLine("Type a password.");
            string maybePassword = Console.ReadLine();
            // Console.WriteLine("First Name: ");
            // string maybeFirstName = Console.ReadLine();
            // Console.WriteLine("Last Name: ");
            // string maybeLastName = Console.ReadLine();  
            Console.WriteLine("Your role: ");
            Console.WriteLine("[1] Employee");
            Console.WriteLine("[2] Manager");
            string maybeRole = Console.ReadLine();
            switch (maybeRole)
            {
                case "1": // Employee
                    maybeRole = "Employee";
                    break;
                case "2": // Manager
                    maybeRole = "Manager";
                    break;
                default:
                    Console.WriteLine("Thank you.");
                    break;
            }
            // Console.WriteLine(maybeFirstName + " " + maybeLastName + " is a " + maybeRole + ".");
            Console.WriteLine("userName: " + maybeUserName + ", password: " + maybePassword + ", Role: " + maybeRole + ".");
            Environment.Exit(0);
        }

        // UserDAO peeps = new UserDAO();
        // peeps.GetAllUsers();

        // Console.WriteLine("Here is a list of what they want you to pay for:");

        // TicketDAO claims = new TicketDAO();
        // claims.GetAllTickets();


        // MANAGER MENU
        // Console.WriteLine("[1] Resolve Tickets");

        // RESOLVE TICKETS MENU
 
        // Console.WriteLine("[3] View Ticket by TicketID");  
        // Console.WriteLine("[4] View Tickets by UserName");
        // Console.WriteLine("[5] View Tickets by Status");

        public void DisplayManagerMenu()
        {
            Console.WriteLine("Choose a task:");
            Console.WriteLine("[1] Create a New Ticket");
            Console.WriteLine("[2] View My Tickets");
            Console.WriteLine("[3] View Ticket by TicketID");  
            Console.WriteLine("[4] View Tickets by UserName");
            Console.WriteLine("[5] View Tickets by Status");
            Console.WriteLine("[6] View Entire User List");
            Console.WriteLine("[7] View Entire Ticket List");                         
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {
                case "1": // Create
                    Console.WriteLine("Show prompts for creating a ticket.");
                    break;
                case "2": // View
                    Console.WriteLine("Run getTicketsByUserName using this userName.");
                    break;
                case "3": // View Ticket by TicketID
                    Console.WriteLine("Show prompts for creating a ticket.");
                    break;
                case "4": // View Tickets by UserName
                    Console.WriteLine("Which user do you want?");
                    string userIWantTicketsFrom = Console.ReadLine();
                    TicketRepository TicketsFromPeepIWant = new TicketRepository();
                    TicketsFromPeepIWant.GetTicketsByUserName(userIWantTicketsFrom);
                    break;   
                case "5": // View Tickets by Status
                    Console.WriteLine("Ask for status.");
                    break;
                case "6": // View Entire User List
                    Console.WriteLine("Here is a list of all users:");
                    UserRepository peeps = new UserRepository();
                    peeps.GetAllUsers();
                    break;
                case "7": // View Entire Ticket List
                    Console.WriteLine("Here is a list of all Tickets:");
                    TicketRepository tickets = new TicketRepository();
                    tickets.GetAllTickets();
                    break;                                      
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            Environment.Exit(0);
        }


        public void DisplayEmployeeMenu()
        {
            Console.WriteLine("Choose a task:");
            Console.WriteLine("[1] Create a New Ticket");
            Console.WriteLine("[2] View My Tickets");
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {
                case "1": // Create
                    Console.WriteLine("Show prompts for creating a ticket.");
                    break;
                case "2": // View
                    Console.WriteLine("Run getTicketsByUserName using this userName.");
                    break;
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            Environment.Exit(0);
        }
    }
}