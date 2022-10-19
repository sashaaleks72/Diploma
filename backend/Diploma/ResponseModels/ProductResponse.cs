namespace Diploma.ResponseModels
{
    public class ProductResponse
    {
        public string Title { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public string ManufacturerCountry { get; set; }

        public double Capacity { get; set; }

        public int WarrantyInMonths { get; set; }

        public string ProductType { get; set; }
    }
}
