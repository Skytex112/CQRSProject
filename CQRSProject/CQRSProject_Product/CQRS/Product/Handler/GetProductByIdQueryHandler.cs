using AutoMapper;
using CQRSProject_Product.CQRS.Product.Command;
using CQRSProject_Product.Data;
using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject_Product.CQRS.Product.Handler
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdCommand, Result<ProductViewProfile>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(AppDbContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Result<ProductViewProfile>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.FindAsync(request.Id, cancellationToken);
            if (result != null)
            {
                var product = _mapper.Map<ProductViewProfile>(result);
                return Result<ProductViewProfile>.Success(product, "Product successfully found");
            }
            return Result<ProductViewProfile>.Failure("Product not found");
        }
    }
}
