using CQRSProject_Product.Data;
using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using FluentValidation;
using MediatR;

namespace CQRSProject_Product.CQRS.Product.Command
{
    public class CreateProductHandler : IRequest<Result<ProductViewProfile>>
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Code { get; set; }
        public Guid CategoryId { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
    }


    public class CreateProductValidator : AbstractValidator<GetProductByIdCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.").Matches(@"^/d{13}$").WithMessage("Barcode must contain exactly 13 digits");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");
            RuleFor(x => x.Discount).InclusiveBetween(0, 100).WithMessage("Price must be greater than 0 and less then 100");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater then 0");
            //New rule for Price.
            RuleFor(x => x.Price).LessThan(100000).WithMessage("Price cannot be this much.");
            

        }
    }
}
