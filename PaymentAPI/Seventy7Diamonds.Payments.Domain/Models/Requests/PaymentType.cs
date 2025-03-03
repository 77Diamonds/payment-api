using System.Runtime.Serialization;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;

public enum PaymentType
{
    [EnumMember(Value = "Regular")] Regular,
    [EnumMember(Value = "Recurring")] Recurring,
    [EnumMember(Value = "MOTO")] Moto,
    [EnumMember(Value = "Installment")] Installment,
    [EnumMember(Value = "Unscheduled")] Unscheduled,
}


