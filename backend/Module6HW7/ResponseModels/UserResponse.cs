using System;

namespace Module6HW7.ResponseModels
{
    public class UserResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Birthday { get; set; }
    }
}
