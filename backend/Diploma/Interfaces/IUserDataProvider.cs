using Diploma.Models;
using System;
using System.Threading.Tasks;

namespace Diploma.Interfaces
{
    public interface IUserDataProvider
    {
        public Task<User> GetUser(Guid userId);

        public Task<bool> ChangeUser(Guid userId, User user);

        public Task<bool> AddUser(User user);

        public Task<User> GetUser(string email, string pass);

        public Task<User> GetUser(string email);
    }
}
