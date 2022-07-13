using Models;
using CustomExceptions;
using System;

namespace Services
{
    public class TicketServices
    {
        
        public User GetUserByUserName(string userWanted)
        {
            throw new ResourceNotFound();
        }



        public User GetUserByUserID(string userWanted)
        {
            throw new ResourceNotFound();
        }


        public User GetAllUsers(string userWanted)
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
        //     //Console.WriteLine("You typed " + maybeUserName + ".");
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
        //     userRole maybeRole = new userRole();
        //     switch (maybeRoleSelector)
        //     {
        //         case "1": // Employee
        //             maybeRole = userRole.Employee; 
        //             break;
        //         case "2": // Manager
        //             maybeRole = userRole.Manager;
        //             break;
        //         default:
        //             Console.WriteLine("Thank you.");
        //             break;
        //     }
            // Console.WriteLine(maybeFirstName + " " + maybeLastName + " is a " + maybeRole + ".");
            //string maybeRoleString = new userRoleToString(maybeRole);
        //     Console.WriteLine(" Attempting to register userName: " + maybeUserName + ", password: " + maybePassword + ", Role: " + maybeRole + ".");

        //     User maybeUser = new AuthServices().RegisterUser(maybeUserName, maybePassword, maybeRole);

        //     //Environment.Exit(0);
        //     DisplayLoginUI();
        // }



    }
}

