namespace SeventySevenDiamonds.Payments.Domain.Models.Common;

public record Phone
{
    public required string CountryCode { get; set; }

    public required string Number { get; set; }
}