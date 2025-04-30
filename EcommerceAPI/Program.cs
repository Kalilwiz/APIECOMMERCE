using System.Text;
using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AquiCometerasLoucurasContext, AquiCometerasLoucurasContext>();    // variacao de addscoped usado apennas para                                                                                                         builder de context

builder.Services.AddTransient<IprodutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemDoPedidoRepository, ItemDoPedidoRepository>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    object True = null;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "ecommerce",
        ValidAudience = "ecommerce",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Minha-Chave-ultra-mega-secreta-Secreta-Senai"))

    };
});

builder.Services.AddAuthentication();

var app = builder.Build();
 
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();