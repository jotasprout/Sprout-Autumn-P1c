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




        public List<User> GetUsers(string those)
        {
            throw new ResourceNotFound();
        }

        public List<User> GetAllUsers()
        {
            throw new ResourceNotFound();
        }

        public User GetUserByUserName(string userWanted)
        {
            throw new ResourceNotFound();
        }             

        public User CreateUser(User newUser)
        {
            throw new ResourceNotFound();
        }

        public User GetUserByUserID(string userID)
        {
            throw new ResourceNotFound();
        }
 
    }
}

