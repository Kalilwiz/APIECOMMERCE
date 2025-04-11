using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<AquiCometerasLoucurasContext, AquiCometerasLoucurasContext>();

builder.Services.AddScoped<IprodutoRepository, ProdutoRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();