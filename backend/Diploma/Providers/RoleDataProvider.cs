using Microsoft.EntityFrameworkCore;
using Diploma.DB;
using Diploma.Interfaces;
using Diploma.Models;
using System.Threading.Tasks;

namespace Diploma.Providers
{
    public class RoleDataProvider : IRoleDataProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleDataProvider(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> GetRole(string roleName)
        {
            var recievedRole = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Title == roleName);

            return recievedRole;
        }
    }
}
