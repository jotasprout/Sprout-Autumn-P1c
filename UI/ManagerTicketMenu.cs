using System;
using Services;
using Models;
using DataAccess;
using CustomExceptions;

namespace UI
{
    public class ManagerTicketMenu
    {

        private static TicketServices _tix;
        public ManagerUserMenu()
        {
            _tix = new TicketServices(new IticketDAO(_tix));
        }

        public void DisplayManagerTicketMenu(User CurrentUserIn)
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
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {
                case "1": // Create
                    TicketRepository newTicket = _tix;
                    newTicket.CreateTicket(CurrentUserIn);  
                    break;
                case "2": // All of MY tickets
                    Console.WriteLine("Here are all your tickets:");
                    TicketRepository myTickets = _tix;
                    int myIDint = CurrentUserIn.userID;
                    string myIDstring = myIDint.ToString();
                    myTickets.GetTicketsByUserID(myIDstring);
                    break;                  
                case "3": // View Ticket by TicketID
                    Console.WriteLine("Enter ticketID.");
                    string ticketIDString = Console.ReadLine();
                    TicketRepository TicketWithThisID = _tix;
                    TicketWithThisID.GrabTicketByTicketID(ticketIDString);                    
                    break;
                case "4": // View Tickets by UserName
                    Console.WriteLine("Which user do you want?");
                    string userIWantTicketsFrom = Console.ReadLine();
                    TicketRepository TicketsFromPeepIWant = _tix;
                    TicketsFromPeepIWant.GetTicketsByUserName(userIWantTicketsFrom);
                    break;   
                case "5": // View Tickets by Status
                    TicketRepository TicketsByStatus = _tix;
                    TicketsByStatus.GetTicketsByStatus();
                    //GetTicketsByStatus();
                    break;          
                case "6": // View Tickets by UserID
                    Console.WriteLine("Enter userID.");
                    string userIDforTicketsFrom = Console.ReadLine();
                    TicketRepository TicketsFromThisUserID = _tix;
                    TicketsFromThisUserID.GetTicketsByUserID(userIDforTicketsFrom);
                    break;                     
                case "7": // View Entire Ticket List
                    Console.WriteLine("Here is a list of all Tickets:");
                    TicketRepository tickets = _tix;
                    tickets.GetAllTickets();
                    break;     
                case "8": // Resolve a ticket               
                    Console.WriteLine("Enter ticketID.");
                    string ticketIDtoResolve = Console.ReadLine();
                    TicketRepository resolvingTicket = _tix;
                    resolvingTicket.ResolveThisTicket(ticketIDtoResolve, CurrentUserIn);                  
                    break;                                                                        
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            //Environment.Exit(0);
        }

    }
}