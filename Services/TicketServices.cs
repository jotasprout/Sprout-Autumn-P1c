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


    }
}

