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
        
        public List<Ticket> GetTicketsByUserName(string userIWantTicketsFor)
        {
            throw new ResourceNotFound();
        }

        public List<Ticket> GrabTicketByTicketID(string ticketID)
        {
            throw new ResourceNotFound();
        }

        public List<Ticket> GetAllTickets()
        {
            throw new ResourceNotFound();
        }

        public List<Ticket> CreateTicket(User CurrentUser)
        {
            throw new ResourceNotFound();
        }


        public List<Ticket> GetTickets(string those)
        {
            throw new ResourceNotFound();

        }
        
        
        public List<Ticket> GetTicketsByUserID(string userIWantTicketsFor)
        {
            throw new ResourceNotFound();

        }


        public List<Ticket> GetTicketsByStatus()
        {
            throw new ResourceNotFound();

        }
        
        public List<Ticket> ResolveThisTicket(string ticketID, User CurrentUserIn)
        {
            throw new ResourceNotFound();

        }


    }
}

