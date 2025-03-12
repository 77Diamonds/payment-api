using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeventySevenDiamonds.Payments.Domain.Entities;

[Table("Payment")]
public class Payment
{
    [Key]
    public required Guid Id { get; set; }
    
    [Key]
    public int Version { get; set; }
    
    public required DateTimeOffset CreatedOn { get; set; }
    
    [Column(TypeName = "jsonb")]
    public string? Request { get; set; }
    
    [Column(TypeName = "jsonb")]
    public string? Response { get; set; }
    
}