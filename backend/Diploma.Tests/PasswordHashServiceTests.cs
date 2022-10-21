using Diploma.Services;

namespace Diploma.Tests
{
    public class PasswordHashServiceTests
    {
        [Fact]
        public void HashPassword_IfHashed_CorrectlyHashedPassword()
        {
            // arrange
            string expected = "5E-88-48-98-DA-28-04-71-51-D0-E5-6F-8D-C6-29-27-73-60-3D-0D-6A-AB-BD-D6-2A-11-EF-72-1D-15-42-D8";
            string passwordToHash = "password";

            // act
            string actual = PasswordHashService.HashPassword(passwordToHash);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
