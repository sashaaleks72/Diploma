using Microsoft.EntityFrameworkCore;
using Diploma.DB;
using Diploma.Interfaces;
using Diploma.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Providers
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public UserDataProvider(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            int quantityOfAddedUsers = await _dbContext.SaveChangesAsync();

            return quantityOfAddedUsers > 0;
        }

        public async Task<bool> ChangeUser(Guid userId, User user)
        {
            _dbContext.Users.Update(user);
            int quantityOfUpdatedRows = await _dbContext.SaveChangesAsync();

            return quantityOfUpdatedRows > 0;
        }

        public async Task<User> GetUser(string email, string hashedPass)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.HashPassword == hashedPass);

            return user;
        }

        public async Task<User> GetUser(string email)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<User> GetUser(Guid userId)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }
    }
}
