using AutoMapper;
using CQRSProject_Product.CQRS.Product.Command;
using CQRSProject_Product.Data;
using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject_Product.CQRS.Product.Handler
{
    public class CreateProductHandler : IRequestHandler<GetProductByIdCommand, Result<ProductViewProfile>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductHandler(AppDbContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

    
        public async Task<Result<ProductViewProfile>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var exists = await _context.Products
                .AnyAsync(x => x.Code == request.Code, cancellationToken);
            if(exists)
            {
                return Result<ProductViewProfile>.Failure("Product with this code allready exist");
            }

            //Something strange with namespaces.
            var product = new CQRSProject_Product.Product.Product()
            {

                Name = request.Name,
                Code = request.Code,
                CategoryId = request.CategoryId,
                Price = request.Price,
                Discount = request.Discount,
                Quantity = request.Quantity,

            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<ProductViewProfile>(product);
            return Result<ProductViewProfile>.Success(result, "Product Creater successfully");
                
            
        }

        //public async Task<Guid> Handler(CreateProductCommand request)
        //{
        //    //Guid Id = Guid.NewGuid();
        //    var product = new Product
        //    {

        //        Name = request.Name,
        //        Price = request.Price
        //    };
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();
        //    return product.Id;
        //}
    }
}
