using AutoMapper;
using CQRSProject_Product.Data;
using CQRSProject_Product.Product;
using CQRSProject_Product.Profiles;
using MediatR;

namespace CQRSProject_Product.CQRS.Product.Query
{
    public class GetAllProductQueryRequest() : IRequest<Result<List<ProductViewProfile>>>
    {
        //private readonly AppDbContext _appDbContext;
        //private readonly IMapper _mapper;
    }

    //public record ProductDTO(Guid Id,string? Name, decimal? Price);
}
