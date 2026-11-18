using AutoMapper;
using CQRSProject_Product.CQRS.Product.Query;
using CQRSProject_Product.Data;
using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject_Product.CQRS.Product.Handler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductQueryRequest, Result<List<ProductViewProfile>>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;   

        public GetAllProductsHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public Task<Result<ProductViewProfile>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<ProductViewProfile>>> Handler(GetAllProductQueryRequest request , CancellationToken cancellation)
        {
            var products = await _appDbContext.Products
                .ToListAsync(cancellation); 
            var result = _mapper.Map<List<ProductViewProfile>>(products);

            return Result<List<ProductViewProfile>>.Success(result);

        }

        Task<Result<List<ProductViewProfile>>> IRequestHandler<GetAllProductQueryRequest, Result<List<ProductViewProfile>>>.Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
