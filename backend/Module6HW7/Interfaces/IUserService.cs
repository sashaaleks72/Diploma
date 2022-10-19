using Module6HW7.Models;
using Module6HW7.ResponseModels;
using Module6HW7.ViewModels;
using System;
using System.Threading.Tasks;

namespace Module6HW7.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponse> GetUserProfile(Guid userId);

        public Task<bool> EditUserProfile(Guid userId, ProfileViewModel editedUser);

        public Task<AuthResponse> Register(RegisterViewModel newUser);

        public Task<AuthResponse> Login(LoginViewModel userToCheck);
    }
}
