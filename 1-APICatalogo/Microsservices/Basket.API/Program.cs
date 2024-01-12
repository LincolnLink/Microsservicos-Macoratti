using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Carrega as configurações do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Obtém o valor de "DiscountUrl"
var discountUrl = builder.Configuration.GetSection("GrpcSettings:DiscountUrl").Value;


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddScoped<DiscountGrpcService>();


builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
    options => options.Address = new Uri(discountUrl));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Basket.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
