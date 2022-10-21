using System;

namespace Diploma.IdentityServer.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Patronymic { get; set; } = string.Empty;

        public string HashPassword { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public virtual Role Role { get; set; } = new Role();
        public int RoleId { get; set; }
    }
}
