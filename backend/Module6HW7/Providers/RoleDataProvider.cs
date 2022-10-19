using Microsoft.EntityFrameworkCore;
using Module6HW7.DB;
using Module6HW7.Interfaces;
using Module6HW7.Models;
using System.Threading.Tasks;

namespace Module6HW7.Providers
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
