using Models;
using CustomExceptions;
using System;

namespace Services
{
    public class TicketServices
    {
        
        public Ticket GetTicketByTicketName(string TicketWanted)
        {
            throw new ResourceNotFound();
        }



        public Ticket GetTicketByTicketID(string TicketWanted)
        {
            throw new ResourceNotFound();
        }


        public Ticket GetAllTickets(string TicketWanted)
        {
            throw new ResourceNotFound();
        }



        // public List<Ticket>  startTicket(
        //     string description,
        //     decimal amount
        // )
        // {
        //     Console.WriteLine("What is it?");
        //     string ticketDescription = Console.ReadLine();
        //     //Console.WriteLine("You typed " + maybeTicketName + ".");
        //     Console.WriteLine("How much?");
        //     string ticketCost = Console.ReadLine();
        //     // Console.WriteLine("First Name: ");
        //     // string maybeFirstName = Console.ReadLine();
        //     // Console.WriteLine("Last Name: ");
        //     // string maybeLastName = Console.ReadLine();  
        //     Console.WriteLine("Your role: ");
        //     Console.WriteLine("[1] Employee");
        //     Console.WriteLine("[2] Manager");
        //     string maybeRoleSelector = Console.ReadLine();
        //     TicketRole maybeRole = new TicketRole();
        //     switch (maybeRoleSelector)
        //     {
        //         case "1": // Employee
        //             maybeRole = TicketRole.Employee; 
        //             break;
        //         case "2": // Manager
        //             maybeRole = TicketRole.Manager;
        //             break;
        //         default:
        //             Console.WriteLine("Thank you.");
        //             break;
        //     }
            // Console.WriteLine(maybeFirstName + " " + maybeLastName + " is a " + maybeRole + ".");
            //string maybeRoleString = new TicketRoleToString(maybeRole);
        //     Console.WriteLine(" Attempting to register TicketName: " + maybeTicketName + ", password: " + maybePassword + ", Role: " + maybeRole + ".");

        //     Ticket maybeTicket = new AuthServices().RegisterTicket(maybeTicketName, maybePassword, maybeRole);

        //     //Environment.Exit(0);
        //     DisplayLoginUI();
        // }



    }
}

