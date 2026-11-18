using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using MediatR;

namespace CQRSProject_Product.CQRS.Product.Command
{
    public class GetProductByIdCommand : IRequest<Result<ProductViewProfile>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Code { get; set; }
        public Guid CategoryId { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
    }
}
