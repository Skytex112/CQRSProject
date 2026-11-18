namespace CQRSProject_Product.Profiles
{
    public class OrderViewProfile
    {
        public decimal Price { get; set; }

        public List<ProductViewProfile>? Products { get; set; }
    }
}
