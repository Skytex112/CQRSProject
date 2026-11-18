using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using FluentValidation;
using MediatR;

namespace CQRSProject_Product.CQRS.Order.Command
{
    public class CreateOrderCommand : IRequest<Result<OrderViewProfile>>
    { 
        public decimal? Price { get; set; }
        public List<ProductViewProfile>? Products { get; set; }
    }

    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand> { 
        public CreateOrderValidator()
        {
            RuleFor(x => x.Price).GreaterThan(100).WithMessage("Your Order must be more expensive than 100.");

        }
    }
}
