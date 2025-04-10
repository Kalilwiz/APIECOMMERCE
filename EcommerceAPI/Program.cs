using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<AquiCometerasLoucurasContext, AquiCometerasLoucurasContext>();

var app = builder.Build();

app.MapControllers();

app.Run();