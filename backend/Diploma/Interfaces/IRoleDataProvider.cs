using Diploma.Models;
using System.Threading.Tasks;

namespace Diploma.Interfaces
{
    public interface IRoleDataProvider
    {
        public Task<Role> GetRole(string roleName);
    }
}
