using CheckoutSDK.Extensions.Configuration;
using MassTransit;
using Seventy7Diamonds.Payment.Infrastructure;
using Seventy7Diamonds.Payments.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCheckoutSdk(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();