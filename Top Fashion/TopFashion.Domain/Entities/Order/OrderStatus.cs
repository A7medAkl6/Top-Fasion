using System.Runtime.Serialization;

namespace Top_Fashion.TopFashion.Domain.Entities.Order
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Payment Received")]

        PaymentReceived,
        [EnumMember(Value = "Payment Faild")]

        PaymentFelid
    }
}
