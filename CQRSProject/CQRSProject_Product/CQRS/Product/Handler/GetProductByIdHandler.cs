using AutoMapper;
using CQRSProject_Product.CQRS.Product.Command;
using CQRSProject_Product.Data;
using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject_Product.CQRS.Product.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommand, Result<ProductViewProfile>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        GetProductByIdHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ProductViewProfile>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var exists = await _context.Products.AnyAsync(x => x.Id == request.Id, cancellationToken);
  
            if (!exists)
            {
                return Result<ProductViewProfile>.Failure("Product with this Id don't exist");
            }

            var product = await _context.Products.FindAsync(exists, cancellationToken);

            var result = _mapper.Map<ProductViewProfile>(product);

            return Result<ProductViewProfile>.Success(result, "Product Successfully found");
        }




    }
}
