using IdentityServer4.Validation;

namespace Diploma.IdentityServer.Services
{
    public class UserValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
