using System;

namespace Diploma.ViewModels
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public int Quantity { get; set; }

        public string ImgUrl { get; set; }

        public double Price { get; set; }
    }
}
