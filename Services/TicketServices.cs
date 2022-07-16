using Models;
using DataAccess;
using CustomExceptions;
using System;

namespace Services
{
    public class TicketServices
    {

        private readonly IticketDAO _repo;
        public TicketServices(IticketDAO repo)
        {
            _repo = repo;
        }
        
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

