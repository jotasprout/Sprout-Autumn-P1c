using Models;
using CustomExceptions;
using DataAccess;
using System;

namespace Services
{
    public class UserServices
    {

        private readonly IuserDAO _repo;
        public UserServices(IuserDAO repo)
        {
            _repo = repo;
        }

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

