namespace CQRSProject_Product.Services
{
    public class OrderService
    {
        private readonly IConfiguration _configuration;

        public OrderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int DiscountChange()
        {
            return _configuration.GetValue<int>("Discount");
        }
    }
}
