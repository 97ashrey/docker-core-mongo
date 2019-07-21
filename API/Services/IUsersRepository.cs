using System;
using System.Collections.Generic;
using API.Entities;

namespace API.Services
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(User user);
        bool UserExists(Guid id);
    }
}
