using AutoMapper;
using Diploma.Interfaces;
using Diploma.Models;
using Diploma.ResponseModels;
using Diploma.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using IdentityModel.Client;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserDataProvider _dataProvider;

        public UserService(IUserDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        public async Task<UserResponse> GetUserProfile(Guid userId)
        {
            var user = await _dataProvider.GetUser(userId);

            if (user == null)
            {
                throw new Exception("User with entered id doesn't exist");
            }

            var userResponse = _mapper.Map<User, UserResponse>(user);

            return userResponse;
        }

        public async Task<bool> EditUserProfile(Guid userId, ProfileViewModel editedUser)
        {
            var userToEdit = await _dataProvider.GetUser(userId);

            if (userToEdit == null)
            {
                throw new Exception("User with entered id doesn't exist");
            }

            userToEdit.FirstName = editedUser.FirstName;
            userToEdit.LastName = editedUser.LastName;
            userToEdit.Patronymic = editedUser.Patronymic;
            userToEdit.Birthday = DateTime.Parse(editedUser.Birthday);

            bool isChanged = await  _dataProvider.ChangeUser(userId, userToEdit);

            return isChanged;
        }

        public async Task<AuthResponse> Register(RegisterViewModel newUser)
        {
            var user = _mapper.Map<RegisterViewModel, User>(newUser);
            var authResponse = new AuthResponse();

            var recievedUserWithEnteredEmail = await _dataProvider.GetUser(user.Email);

            if (recievedUserWithEnteredEmail != null)
            {
                throw new Exception("The user with entered email already exists!");
            }

            bool isAdded = await _dataProvider.AddUser(user);

            if (isAdded)
            {
                string token = await GetAccessToken(newUser.Email, newUser.Pass);
                var userResponse = _mapper.Map<User, UserResponse>(user);

                authResponse.AccessToken = token;
                authResponse.User = userResponse;
            }

            return authResponse;
        }

        public async Task<AuthResponse> Login(LoginViewModel userToCheck)
        {
            var authResponse = new AuthResponse();

            string token = await GetAccessToken(userToCheck.Email, userToCheck.Pass);
            var user = await _dataProvider.GetUser(userToCheck.Email, PasswordHashService.HashPassword(userToCheck.Pass));

            if (user != null)
            {
                var userResponse = _mapper.Map<User, UserResponse>(user);

                authResponse.AccessToken = token;
                authResponse.User = userResponse;
            }

            return authResponse;
        }

        private async Task<string> GetAccessToken(string userName, string password)
        {
            using (var httpClient = new HttpClient())
            {

                var discoveryDocument = await httpClient.GetDiscoveryDocumentAsync("https://localhost:44382");
                var token = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest 
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "react_login",
                    ClientSecret = "react_pass",
                    Scope = "openid",
                    GrantType = "password",
                    UserName = userName,
                    Password = password
                });

                if (token.IsError)
                {
                    throw new Exception(token.ErrorDescription);
                }

                return token.AccessToken;
            }
        }
    }
}
