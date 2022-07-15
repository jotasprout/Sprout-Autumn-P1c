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



        public List<Ticket>  CreateTicket()
        {
            throw new ResourceNotFound();
        }

    }
}

