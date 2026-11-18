namespace CQRSProject_Product.Services
{
    public class ProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int GetMaxProductPerPage()
        {
            return _configuration.GetValue<int>("MaxProductPerPage");
        }
    }
}
