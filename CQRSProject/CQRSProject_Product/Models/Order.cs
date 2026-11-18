namespace CQRSProject_Product.Product
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public decimal Price { get; set; }

        public List<Product>? Products { get; set; }
    }
}
