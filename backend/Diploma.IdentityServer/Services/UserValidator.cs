using Diploma.IdentityServer.DB;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Module6HW7.Services;

namespace Diploma.IdentityServer.Services
{
    public class UserValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserDbContext _dbContext;

        public UserValidator(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            string email = context.UserName;
            string pass = PasswordHashService.HashPassword(context.Password);

            if (_dbContext.Users.Any(u => u.Email == email && u.HashPassword == pass))
            {
                context.Result = new GrantValidationResult(email, "pwd");
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Invalid credentials");
            return Task.CompletedTask;
        }
    }
}
