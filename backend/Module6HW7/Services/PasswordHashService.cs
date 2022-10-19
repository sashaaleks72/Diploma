using System;
using System.Security.Cryptography;
using System.Text;

namespace Module6HW7.Services
{
    public class PasswordHashService
    {
        public static string HashPassword(string passwordToHash)
        {
            var sha256 = SHA256.Create();

            byte[] encodedIntoBytesString = Encoding.UTF8.GetBytes(passwordToHash);
            byte[] hash = sha256.ComputeHash(encodedIntoBytesString);

            string hashedPass = BitConverter.ToString(hash);

            return hashedPass;
        }
    }
}
