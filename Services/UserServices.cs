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

        public List<Ticket> GetTicketsByUserID()
        {
            throw new ResourceNotFound();
        }

        public List<Ticket> GetTicketsByStatus()
        {
            throw new ResourceNotFound();
        }
 
    }
}

