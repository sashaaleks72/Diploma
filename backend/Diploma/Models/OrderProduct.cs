using System;

namespace Diploma.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }

        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
