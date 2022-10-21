using System;
using System.Collections.Generic;

namespace Diploma.ViewModels
{
    public class OrderViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Department { get; set; }

        public string DeliveryAddress { get; set; }

        public List<CartItemViewModel> CartItems { get; set; }

        public double TotalSum { get; set; }

        public Guid UserId { get; set; }
    }
}
