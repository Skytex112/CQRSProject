using CQRSProject_Product.CQRS.Product.Command;
using CQRSProject_Product.CQRS.Product.Query;
using CQRSProject_Product.Data;
using CQRSProject_Product.Profiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CQRSProject_Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AppSettingsProfile _appSettngs;

        //For configurations
        private readonly UserSettingProfile _userSetting;
        private readonly AdminSettingProfile _adminSetting;
        private readonly SuperAdminSettingProfile _superAdminSettingProfile;

        //For Pagination
        private readonly PaginationSettingProfile _pagination;

        private readonly AppDbContext _context;

        public ProductController(IMediator mediator, IOptions<AppSettingsProfile> configuration,
            IOptions<UserSettingProfile> userOptions,
            IOptions<AdminSettingProfile> adminOptions,
            IOptions<SuperAdminSettingProfile> _superAdminOptions,

            IOptions<PaginationSettingProfile> paginationOptions


            , AppDbContext context)
        {
            _mediator = mediator;
            _appSettngs = configuration.Value;
            _context = context;

            _userSetting = userOptions.Value;
            _adminSetting = adminOptions.Value;
            _superAdminSettingProfile = _superAdminOptions.Value;

            _pagination = paginationOptions.Value;
        }

        [HttpGet("pagination")]
        public IActionResult GetPaginationSettings()
        {
            return Ok(new
            {
                PageAmount = _pagination.PageAmount,
                AmountOfProducts = _pagination.AmountOfProducts

            });
        }



        [HttpGet("userConfig")]
        public IActionResult GetUserConfig()
        {
            return Ok(new
            {
                Email = _userSetting.Email,
                Password = _userSetting.Password,
                Role = _userSetting.Role,
                Discount = _userSetting.Discount,

            });
        }

        [HttpGet("adminConfig")]
        public IActionResult GetAdminConfig()
        {
            return Ok(new
            {
                Email = _adminSetting.Email,
                Password = _adminSetting.Password,
                Role = _adminSetting.Role,
                Discount = _adminSetting.Discount,
            });
        }

        [HttpGet("superAdminConfig")]
        public IActionResult GetSuperAdminConfig()
        {
            return Ok(new
            {
                Email = _superAdminSettingProfile.Email,
                Password = _superAdminSettingProfile.Password,
                Role = _superAdminSettingProfile.Role,
                Discount = _superAdminSettingProfile.Discount,
            });
        }


        [HttpGet("config")]
        public IActionResult GetConfig()
        {
            return Ok(new
            {
                AppName = _appSettngs.ApplicationName,
                MaxProducts = _appSettngs.MaxProductPerPage
            });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(result);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Create()
        {
            var result = await _mediator.Send(new CreateProductHandler());
            if (!result.IsSuccess) { return BadRequest(result); }
            return Ok(result);
        }
    }
}
