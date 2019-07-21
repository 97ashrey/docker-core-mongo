using System;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using API.Config;

namespace API.Services
{
    public class UsersRepository : IUsersRepository
    {
        private IMongoCollection<User> users;

        public UsersRepository(IMongoDBConfig config)
        {
            MongoClient client = new MongoClient(config.ConnectionString);
            IMongoDatabase db = client.GetDatabase(config.Database);
            users = db.GetCollection<User>("Users");
        }

        public User CreateUser(User user)
        {
            users.InsertOne(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            users.DeleteOne(model => model.Id == user.Id);
            return user;
        }

        public User GetUser(Guid id)
        {
            return users.Find(book => book.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return users.Find(user => true).ToList();
        }

        public User UpdateUser(User user)
        {
            users.ReplaceOne(model => model.Id == user.Id, user);
            return user;
        }

        public bool UserExists(Guid id)
        {
            User user = GetUser(id);
            return user != null;
        }
    }
}
