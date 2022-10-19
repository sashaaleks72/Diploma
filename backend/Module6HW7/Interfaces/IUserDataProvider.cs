using Module6HW7.Models;
using System;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
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
