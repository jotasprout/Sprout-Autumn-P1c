using Models;
using CustomExceptions;
//using DataAccess;
using System;

namespace Services
{
    public class UserServices
    {

        public List<Ticket> CreateTicket()
        {
            throw new ResourceNotFound();
        }

        // UPDATE/process = approve or deny 



        // Get a ticket by ticketID

        public List<Ticket> GetTicketsByTicketID()
        {
            throw new ResourceNotFound();
        }

        public List<Ticket> GetMyTickets()
        {
            throw new ResourceNotFound();
        }

        public List<Ticket> FilterTicketsByCost()
        {
            throw new ResourceNotFound();
        }               

        // Get all tickets by userID

        public List<Ticket> GetTicketsByUserID()
        {
            throw new ResourceNotFound();
        }

        // GET TICKET BY STATUS

        public List<Ticket> GetTicketsByStatus()
        {
            throw new ResourceNotFound();
        }

     
        
    }
}

