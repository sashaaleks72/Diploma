using Diploma.Models;
using Diploma.ResponseModels;
using Diploma.ViewModels;
using System;
using System.Threading.Tasks;

namespace Diploma.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponse> GetUserProfile(Guid userId);

        public Task<bool> EditUserProfile(Guid userId, ProfileViewModel editedUser);

        public Task<AuthResponse> Register(RegisterViewModel newUser);

        public Task<AuthResponse> Login(LoginViewModel userToCheck);
    }
}
