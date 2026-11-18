using CQRSProject_Product.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<AppSettingsProfile>(builder.Configuration.GetSection("AppSettings"));
//User
builder.Services.Configure<UserSettingProfile>(builder.Configuration.GetSection("SeedUser"));
//Admin
builder.Services.Configure<AdminSettingProfile>(builder.Configuration.GetSection("SeedAdmin"));
//Super Admin
builder.Services.Configure<SuperAdminSettingProfile>(builder.Configuration.GetSection("SeedSuperAdmin"));
//Pagination setting
builder.Services.Configure<PaginationSettingProfile>(builder.Configuration.GetSection("PaginationSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
