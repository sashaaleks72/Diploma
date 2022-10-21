using System;

namespace Diploma.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Department { get; set; }

        public string DeliveryAddress { get; set; }

        public double TotalSum { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public int OrderStatusId { get; set; }

        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
