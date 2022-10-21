using System;

namespace Diploma.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string HashPassword { get; set; }

        public DateTime Birthday { get; set; }

        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
