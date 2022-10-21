using Diploma.ViewModels;
using System;
using System.Collections.Generic;

namespace Diploma.ResponseModels
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Department { get; set; }

        public string DeliveryAddress { get; set; }

        public List<CartItemResponse> CartItems { get; set; }

        public string OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public double TotalSum { get; set; }
    }
}
