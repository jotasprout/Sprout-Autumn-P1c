using System;
using Services;
using Models;
using DataAccess;
using CustomExceptions;

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
            User userKnocking;
            try
            {
                userKnocking = new AuthServices().LoginUser(userName, password);
                if (userKnocking.password == password && userKnocking.userName == userName)
                {
                    if (userKnocking.userRole == userRole.Manager)
                    {
                        // If user is a Manager, display Manager Menu
                        DisplayManagerMenu(userKnocking);
                    }
                    else 
                    {
                        Console.WriteLine("Show Employee stuff.");
                        DisplayEmployeeMenu(userKnocking);
                    }
                }
                else
                {
                    Console.WriteLine("Access Denied");
                    Environment.Exit(0);
                }
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound("We don't seem to have anyone by that name.");
                Environment.Exit(0);
            }
            catch (InvalidCredentials)
            {
                throw new InvalidCredentials("those creds don't work.");
                Environment.Exit(0);
            }
            //Environment.Exit(0);
        }



        public void DisplayRegisterUI()
        {
            Console.WriteLine("Choose a userName");
            string maybeUserName = Console.ReadLine();
            Console.WriteLine("You typed " + maybeUserName + ".");
            Console.WriteLine("Type a password.");
            string maybePassword = Console.ReadLine();
            Console.WriteLine("Your role: ");
            Console.WriteLine("[1] Employee");
            Console.WriteLine("[2] Manager");
            string maybeRoleSelector = Console.ReadLine();
            userRole maybeRole = new userRole();
            switch (maybeRoleSelector)
            {
                case "1": // Employee
                    maybeRole = userRole.Employee; 
                    break;
                case "2": // Manager
                    maybeRole = userRole.Manager;
                    break;
                default:
                    Console.WriteLine("Thank you.");
                    break;
            }
            Console.WriteLine(" Attempting to register userName: " + maybeUserName + ", password: " + maybePassword + ", Role: " + maybeRole + ".");
            User maybeUser = new AuthServices().RegisterUser(maybeUserName, maybePassword, maybeRole);
            //Environment.Exit(0);
            DisplayLoginUI();
        }




        // MANAGER MENU
        // Filter Tickets by Status     

        // RESOLVE TICKETS MENU
        // Console.WriteLine("[5] View Tickets by Status");
        // Which ticket do you want to resolve? 


        //User userLoggingIn = new User();

        public void DisplayManagerMenu(User userLoggingIn)
        {
            Console.WriteLine("Choose a task:");
            Console.WriteLine("[1] Create a New Ticket");
            Console.WriteLine("[2] My Tickets");
            Console.WriteLine("[3] View Ticket by TicketID");  
            Console.WriteLine("[4] View Tickets by UserName");
            Console.WriteLine("[5] View Tickets by Status");
            Console.WriteLine("[6] View Tickets by UserID");
            Console.WriteLine("[7] View Entire Ticket List"); 
            Console.WriteLine("[8] Approve or Deny a Ticket");             
            Console.WriteLine("[9] View Entire User List");                        
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {
                case "1": // Create
                    Console.WriteLine("Show prompts for creating a ticket.");
                    break;
                case "2": // All of MY tickets
                    Console.WriteLine("Here all your tickets:");
                    TicketRepository myTickets = new TicketRepository();
                    int myIDint = userLoggingIn.userID;
                    string myIDstring = myIDint.ToString();
                    myTickets.GetTicketsByUserID(myIDstring);
                    break;                  
                case "3": // View Ticket by TicketID
                    Console.WriteLine("Enter ticketID.");
                    string ticketIDString = Console.ReadLine();
                    TicketRepository TicketWithThisID = new TicketRepository();
                    TicketWithThisID.GrabTicketByTicketID(ticketIDString);                    
                    break;
                case "4": // View Tickets by UserName
                    Console.WriteLine("Which user do you want?");
                    string userIWantTicketsFrom = Console.ReadLine();
                    TicketRepository TicketsFromPeepIWant = new TicketRepository();
                    TicketsFromPeepIWant.GetTicketsByUserName(userIWantTicketsFrom);
                    break;   
                case "5": // View Tickets by Status
                    TicketRepository TicketsByStatus = new TicketRepository();
                    TicketsByStatus.GetTicketsByStatus();
                    //GetTicketsByStatus();
                    break;          
                case "6": // View Tickets by UserID
                    Console.WriteLine("Enter userID.");
                    string userIDforTicketsFrom = Console.ReadLine();
                    TicketRepository TicketsFromThisUserID = new TicketRepository();
                    TicketsFromThisUserID.GetTicketsByUserID(userIDforTicketsFrom);
                    break;                     
                case "7": // View Entire Ticket List
                    Console.WriteLine("Here is a list of all Tickets:");
                    TicketRepository tickets = new TicketRepository();
                    tickets.GetAllTickets();
                    break;     
                case "8": // Resolve a ticket
                    Console.WriteLine("Enter ticketID.");
                    string ticketIDString = Console.ReadLine();
                    TicketRepository TicketWithThisID = new TicketRepository();
                    TicketWithThisID.ResolveThisTicket(ticketIDString);                    
                    break;                      
                case "9": // View Entire User List
                    Console.WriteLine("Here is a list of all users:");
                    UserRepository peeps = new UserRepository();
                    peeps.GetAllUsers();
                    break;                                                    
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            Environment.Exit(0);
        }

        public void DisplayEmployeeMenu(User userLoggingIn)
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
                    Console.WriteLine("Tickets submitted by .");
                    TicketRepository myTickets = new TicketRepository();
                    int myIDint = userLoggingIn.userID;
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