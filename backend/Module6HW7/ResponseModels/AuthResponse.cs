namespace Module6HW7.ResponseModels
{
    public class AuthResponse
    {
        public UserResponse User { get; set; }

        public string AccessToken { get; set; }
    }
}
