using Microsoft.EntityFrameworkCore;
namespace Seventy7Diamonds.Payment.Infrastructure.Database;

public class PaymentDbContext: DbContext
{
    public PaymentDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<SeventySevenDiamonds.Payments.Domain.Entities.Payment> Payments { get; set; }
}