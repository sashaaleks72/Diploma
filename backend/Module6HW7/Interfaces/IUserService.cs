using Module6HW7.Models;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface IUserService
    {
        public Task<bool> RegisterUser(User user);
    }
}
