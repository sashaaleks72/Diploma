using Module6HW7.Models;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface IUserDataProvider
    {
        public Task<bool> AddUser(User user);
        public Task<User> GetUser(string login, string pass);
    }
}
