using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AquiCometerasLoucurasContext, AquiCometerasLoucurasContext>();    // variacao de addscoped usado apennas para                                                                                                         builder de context

builder.Services.AddTransient<IprodutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

var app = builder.Build();
 
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();