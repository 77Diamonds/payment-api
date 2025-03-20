using CheckoutSDK.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Seventy7Diamonds.Payment.Infrastructure;
using Seventy7Diamonds.Payments.Application;


const string permissiveCors = "permissiveCors";

var builder = WebApplication.CreateBuilder(args);

// IOption configurations
builder.Services.Configure<Seventy7Diamonds.Payment.Infrastructure.Options.CheckoutOptions>(
    builder.Configuration.GetSection(Seventy7Diamonds.Payment.Infrastructure.Options.CheckoutOptions.SectionName));


builder.Services.AddControllers();
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCheckoutSdk(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddCors(o =>
{
    o.AddPolicy(permissiveCors, policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

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