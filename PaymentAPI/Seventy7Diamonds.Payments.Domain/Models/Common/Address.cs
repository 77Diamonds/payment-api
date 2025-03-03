namespace SeventySevenDiamonds.Payments.Domain.Models.Common;

public record Address
{
    public required string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public required string City { get; set; }

    public required string State { get; set; }

    public required string Zip { get; set; }

    public CountryCode? Country { get; set; }
}